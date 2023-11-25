using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Models
{
    public class GroupMember
    {
        public int GId { get; set; }
        public string MId { get; set; }
        public virtual Group group { get; set; }
        public virtual Member member { get; set; }
    }
}
