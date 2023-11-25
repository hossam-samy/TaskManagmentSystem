using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core.interfaces
{
    public interface IGroupRepo:IBaseRepo<Group>
    {
        Task<Group> Create(GroupDto group);    
        Task<Project>AddProject(string projectname,string groupname,string managerid);
        Task<Member> AddMember(string membername, string groupname, string managerid);

        Task<List<GroupResponseDto>> ViewAll();
       // Task<string> DeleteGroup(string groupname);



    }
}
