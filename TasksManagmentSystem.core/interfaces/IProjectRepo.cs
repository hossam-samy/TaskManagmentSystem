using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core.interfaces
{
    public interface IProjectRepo:IBaseRepo<Project>
    {
        public string Write(ProjectDto input,string username);   
        
       // public Task<Project> Write(ProjectDto input,string username);   

        

    }
}
