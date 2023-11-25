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
    public class ProjectRepo : BaseRepo<Project>, IProjectRepo
    {
        private readonly AppDbContext Context;

        public ProjectRepo(AppDbContext dbContext):base(dbContext) { }
         
        public string Write(ProjectDto input, string managerid)
        {
            var projectResult = dbContext.Projects.FirstOrDefault(b =>b.Name==input.Name&&b.manager.Id== managerid);
            if (projectResult is not null) return "Project name should be uniqe";
            

            var project =new Project(); 
            project.Name = input.Name;
            project.Status = input.Status;
           // project.StartDate = input.StartDate;
            //project.EndDate = input.EndDate;
            project.ManagerId = managerid;



            dbContext.Add(project);  

            dbContext.SaveChanges();
            return "Succeeded";
        }
    }
}
