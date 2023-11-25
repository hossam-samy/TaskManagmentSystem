using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;
using TasksManagmentSystem.EF.Repos;

namespace TasksManagmentSystem.EF
{
    public class UnitofWork:IUnitofWork
    {
        private readonly AppDbContext context;
       
       // public IBaseRepo<Project> Projects {  get; private set; }

        public IAuthService authService { get; private set; }

        public IProjectRepo projectRepo { get; private set; }

        public IGroupRepo groupRepo { get; private set; }

        public IMemberRepo memberRepo { get; private set; }

        public IManagerRepo managerRepo { get; private set; }

        public IBaseRepo<Task_> Tasks { get; private set; }

        public UnitofWork(AppDbContext context,IAuthService service)
        {
            this.context = context;
            managerRepo = new ManagerRepo(context);
            authService = service;
            projectRepo =new ProjectRepo(context);  
              memberRepo =new MemberRepo(context);  
             groupRepo =new GroupRepo(context);
            Tasks = new BaseRepo<Task_>(context);      
        }
        
        public void Dispose()
        {
            context.Dispose();  

        }
    }
}
        