using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManagmentSystem.core.Dtos
{
    public class GroupDto
    {
        public string Name { get; set; }
        public string? ManagerId { get; set; }
    }
}
