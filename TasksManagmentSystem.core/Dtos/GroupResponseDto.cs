using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core.Dtos
{
    public class GroupResponseDto
    {
        public GroupResponseDto()
        {
            
        }
        public GroupResponseDto(List<Project> projects, List<Member> members)
        {
            foreach (var item in projects)
            {
                Projects.Add(new ProjectDto { Name = item.Name, Status = item.Status });

            }
            foreach (var item in members)
            {
                Members.Add(new MemberResDto { UserName = item.UserName, Email = item.Email });
            }

        }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public List<ProjectDto> Projects { get; set; }= new List<ProjectDto>();

        public List<MemberResDto> Members { get; set; } = new List<MemberResDto>();


    }
}
