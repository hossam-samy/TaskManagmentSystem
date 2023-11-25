using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class GroupProject
    {
        public int GId { get; set; } 
        public int PId { get; set; }
        public virtual Group group { get; set; }
        public virtual Project project { get; set; }
    }
}
