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
        public string Spec { get; set; }
       
        public string ManagerId { get; set; }

        public virtual Manager manager { get; set; }
        public virtual ICollection<Task_> Tasks { get; set; } = new List<Task_>();
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

        public virtual ICollection<GroupMember> groupMembers { get; set; } = new List<GroupMember>();

    }
}
