using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class Member
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string spec { get; set; }
        public int ManagerId { get; set; }
        public Manager manager { get; set; }
        public List<Task_> Tasks { get; set; }
        public List<Group> Groups { get; set; }


    }
}
