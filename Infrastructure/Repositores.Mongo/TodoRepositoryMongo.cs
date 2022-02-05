using Core.Model;
using Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repositores.Mongo
{
    public class TodoRepositoryMongo : ITodoRepository
    {
        private IMongoCollection<Todo> mongoCollection;
        public TodoRepositoryMongo(IOptions<MongoDbSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            this.mongoCollection = mongoDatabase.GetCollection<Todo>(options.Value.CollectionName);

        }

        public Task Delete(Todo todo)
        {
            return this.mongoCollection.DeleteOneAsync(t => t.Id == todo.Id);
        }

        public Task<Todo> GetById(Guid id)
        {
            return this.mongoCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Todo>> GetTodos()
        {
            return this.mongoCollection.Find(_ => true).ToListAsync();
        }

        public Task Insert(Todo todo)
        {
            return this.mongoCollection.InsertOneAsync(todo);
        }

        public Task Update(Todo todo)
        {
            return this.mongoCollection.ReplaceOneAsync(t => t.Id == todo.Id, todo);
        }
    }
}
