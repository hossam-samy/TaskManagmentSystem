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
        IBaseRepo<Manager>Managers {  get; }    
        IAuthService authService { get; }
        
    }
}
