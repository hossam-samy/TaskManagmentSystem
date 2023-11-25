using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;

namespace TasksManagmentSystem.core.Models
{
    public class Task_
    {
        public Task_()
        {
            
        }
        public Task_(TaskDto task)
        {
            Description = task.Description; 
            StartDate = (DateTime) task.StartDate;
            EndDate = (DateTime)task.EndDate; 
            Status = task.Status;   
        }
        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "S";

        
        public string MemberId { get; set; }
       
        public string ManagerId { get; set; }
        
        public int ProjectId { get; set; }
       
        
        public virtual  Manager manager { get; set; }
        public virtual Member member { get; set; }
       public virtual Project project { get; set; }


    }
}
