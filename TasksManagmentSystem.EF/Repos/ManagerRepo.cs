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
    public class ManagerRepo:BaseRepo<Manager>,IManagerRepo
    {
        private readonly AppDbContext _appDbContext;
        public ManagerRepo(AppDbContext appDbContext):base(appDbContext)    
        {
            
        }

        public async Task<string> AssignTask(string memberid,string managerid, TaskDto input)
        {
            var member = dbContext.Members.FirstOrDefault(b => b.Id == memberid);
        
            if (member == null) { return null; }
            var task = new Task_(input);
            task.ManagerId = member.Id; 

            member.Tasks.Add(task);
            dbContext.SaveChanges();
            return "Succeeded";

        }
    }
}
