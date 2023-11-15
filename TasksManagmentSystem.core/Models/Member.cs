using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class Member:User
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Spec { get; set; }
        public Manager manager { get; set; }
        public List<Task_> Tasks { get; set; }
        public List<Group> Groups { get; set; }


    }
}
