using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.EF.Repos
{
    public class GroupRepo:BaseRepo<Group>,IGroupRepo
    {
        private readonly AppDbContext _appDbContext;
        public GroupRepo(AppDbContext appDbContext):base(appDbContext) { }

        public async Task<Project> AddProject(string projectname, string groupname, string managerid)
        {
            var found=dbContext.Projects.FirstOrDefault(b => b.Name == projectname && b.ManagerId == managerid);
            if(found == null) {
                return null;
            }
           var group=dbContext.Groups.FirstOrDefault(b => b.Name == groupname && b.ManagerId == managerid);
            group.Projects = new List<Project>{found };
            
            dbContext.SaveChanges();
            return found;   
        }
        public async Task<Member> AddMember(string membername, string groupname, string managerid)
        {
            var found = dbContext.Members.FirstOrDefault(b => b.UserName == membername && b.ManagerId == managerid);
            if (found == null)
            {
                return null;
            }
            var group = dbContext.Groups.FirstOrDefault(b => b.Name == groupname && b.ManagerId == managerid);
            group.Members = new List<Member> { found };

            dbContext.SaveChanges();
            return found;
        }

        public async Task<Group> Create(GroupDto model)
        {
            var group= dbContext.Groups.FirstOrDefault(b=>b.Name== model.Name&&b.ManagerId==model.ManagerId);
            if (group != null)
            {
                return null;
            }
            group=new Group() { Name=model.Name, ManagerId=model.ManagerId  } ; 
           

            dbContext.Groups.Add(group);    

            dbContext.SaveChanges();

            return group;
        }

        public async Task<List<GroupResponseDto>> ViewAll()
        {
            var nlst =new List<GroupResponseDto>();

            var lst=dbContext.Groups.ToList();
            foreach (var item in lst)
            {
                nlst.Add(new GroupResponseDto(item.Projects.ToList(), item.Members.ToList()) { Name = item.Name, ManagerName = item.manager.UserName });
            }
            return nlst;
        }

        //public async Task<string> DeleteGroup(string groupname)
        //{

        //}
    }
}
