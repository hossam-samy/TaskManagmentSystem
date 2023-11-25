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
    public class MemberRepo:BaseRepo<Member>,IMemberRepo
    {
        private  readonly AppDbContext _appDbContext;
        public MemberRepo(AppDbContext appDbContext):base(appDbContext) {}

        public async Task<MemberDto> Delete(string id)
        {
            var member=dbContext.Members.Where(b=>b.Id==id).FirstOrDefault();
            if (member == null)
            {
                return null;
            }
            var _member = new MemberDto(member); 
            dbContext.Members.Remove(member);
            dbContext.SaveChanges();
            return _member;
        }
    }
}
