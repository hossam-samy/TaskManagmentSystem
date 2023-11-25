using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.core.Dtos
{
    public class MemberDto
    {
        public MemberDto()
        {
            
        }
        public MemberDto(Member member)
        {
            Managerid = member.ManagerId;
            Spec = member.Spec;
            FirstName = member.FirstName;
            LastName = member.LastName;
            
            Phone = member.PhoneNumber;

            UserName = member.UserName;
        }
        public string? Spec { get; set; }
        
        public string? Managerid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }


        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }

    }
}
