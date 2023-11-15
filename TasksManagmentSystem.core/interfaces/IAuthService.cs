using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core.interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> Register(RegesterDto manager);
        Task<AuthModel> Login(LoginDto model);

    }
}
