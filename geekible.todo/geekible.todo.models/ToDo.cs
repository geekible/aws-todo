using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekible.todo.models
{
    public class ToDo : BaseModel
    {
        public string AssignedToUserId { get; set; }
        public string AssignedByUserId { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime StartDate { get; set; }
        public int StartHour { get; set; }
        public int StartMins { get; set; }
        public DateTime DueDate { get; set; }
        public int DueHour { get; set; }
        public int DueMins { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; } = 1;
    }
}
