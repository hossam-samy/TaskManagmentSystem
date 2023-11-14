using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;

namespace TasksManagmentSystem.core.Models
{
    public class Manager
    {
        public Manager() { }

        public Manager(ManagerLoginDto manager)
        {
            Name = manager.Name;
            Password = manager.Password;
        }
        public Manager(ManagerRegesterDto manager)
        {
            Name = manager.Name;    

            Email = manager.Email;
            Password = manager.Password;
            Phone = manager.Phone;
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public List<Member> Members { get; set; }
        public List<Project> Projects { get; set; }
        public List<Group> Groups { get; set; }
        public List<Task_> Tasks { get; set; }
        





    }
}
