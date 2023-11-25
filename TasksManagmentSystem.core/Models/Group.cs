using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ManagerId { get; set; }

        public virtual Manager manager { get; set; }
       public virtual ICollection<Member> Members { get; set; }= new List<Member>(); 
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<GroupProject> groupProjects { get; set; } = new List<GroupProject>();
        public virtual ICollection<GroupMember> groupMembers { get; set; } = new List<GroupMember>();


    }
}
