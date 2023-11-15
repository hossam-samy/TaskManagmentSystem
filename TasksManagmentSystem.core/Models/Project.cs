using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

       
        public Manager manager { get; set; }

        public List<Group> Groups { get; set; }
        public List<Task_> Tasks { get; set; }

    }
}
