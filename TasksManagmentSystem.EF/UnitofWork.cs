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
        public IBaseRepo<Manager> Managers {  get; private set; }

        public IAuthService authService { get; private set; }
        

        public UnitofWork(AppDbContext context,IAuthService service)
        {
            this.context = context;
            Managers = new BaseRepo<Manager>(context);
            authService = service;
        }
        
        public void Dispose()
        {
            context.Dispose();  

        }
    }
}
        