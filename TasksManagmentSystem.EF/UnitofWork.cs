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
        public UnitofWork(AppDbContext context)
        {
            this.context = context;
            Managers = new BaseRepo<Manager>(context);
        }
        
        public void Dispose()
        {
            context.Dispose();  

        }
    }
}
        