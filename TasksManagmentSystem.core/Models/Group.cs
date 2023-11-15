using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

       
        public Manager manager { get; set; }
        public List<Member> Members { get; set; }
        public List<Project> Projects { get; set; }

    }
}
