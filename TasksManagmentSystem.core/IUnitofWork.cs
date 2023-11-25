using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core
{
    public interface IUnitofWork:IDisposable
    {
       
        IBaseRepo<Task_>Tasks {  get; }   
        IProjectRepo projectRepo { get; }
        IGroupRepo groupRepo { get; }
        IAuthService authService { get; }
        IMemberRepo memberRepo { get; } 
        IManagerRepo managerRepo { get; }   
        
    }
}
