using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;

namespace TasksManagmentSystem.core.Models
{
    public class Manager: User
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public List<Member> Members { get; set; }
        public List<Project> Projects { get; set; }
        public List<Group> Groups { get; set; }
        public List<Task_> Tasks { get; set; }
        
    }
}
