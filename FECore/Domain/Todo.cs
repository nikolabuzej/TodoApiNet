using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECore.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
