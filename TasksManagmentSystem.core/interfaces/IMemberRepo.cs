using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core.interfaces
{
    public interface IMemberRepo:IBaseRepo<Member>
    {
        public Task<MemberDto> Delete(string id);
    }
}
