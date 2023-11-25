using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Models;


namespace TasksManagmentSystem.core.Dtos
    {
        public class ManagerDto
        {
        public ManagerDto() { } 
        public ManagerDto(Manager manager)
        {
            Email = manager.Email;
            FirstName = manager.FirstName;
            LastName = manager.LastName;
           
            Phone = manager.PhoneNumber;
           
            UserName = manager.UserName;
        }
        public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? UserName { get; set; }


            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? Phone { get; set; }
        }
    }



