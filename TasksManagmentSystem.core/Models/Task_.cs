using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class Task_
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public int ManagerId { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        public Manager manager { get; set; }
        public Member member { get; set; }
        public Project project { get; set; }


    }
}
