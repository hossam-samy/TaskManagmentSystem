using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class Project
    {
        public int Id { get; set; }
       
        private string name;
        public string Name { 
            get => name;
            

            set { 
              if(value != null)  name = value; 
            }
        
        }
        

        private string status="S";
        public string Status
        {
            get=>  status;
            

            set
            {
                if (value != null) status = value;
            }

        }
        
        
        
       
        public string ManagerId { get; set; }

        public virtual Manager manager { get; set; }
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();  
        public virtual ICollection<GroupProject> groupProjects { get; set; } = new List<GroupProject>();
        public virtual ICollection<Task_> Tasks { get; set; } = new List<Task_>();   
      


    }
}
