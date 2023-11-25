using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.Dtos;

namespace TasksManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IUnitofWork work;

        public MembersController(IUnitofWork work)
        {
            this.work = work;
        }

        [HttpPut]
        public async Task<IActionResult>UpdateMember([FromForm]string memberId, [FromForm] MemberDto input)
        {
            var member = work.memberRepo.Get(b=>b.Id==memberId).FirstOrDefault();
             if (member == null) {return NotFound();}   
            if(member.UserName is not null)
            member.UserName = input.UserName;
            
            if(member.Email is not null)
            member.Email = input.Email;

            if (member.PhoneNumber is not null)
                member.PhoneNumber = input.Phone;

            if (member.FirstName is not null)
            member.FirstName = input.FirstName;
            if (member.LastName is not null)
            member.LastName = input.LastName;
            if (member.Spec is not null)
            member.Spec = input.Spec;

            var result = await work.memberRepo.Update(member);
            return Ok(input);
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteMember(string id)
        {
            var result =await work.memberRepo.Delete(id);
            return Ok(result);

        }
    }
}
