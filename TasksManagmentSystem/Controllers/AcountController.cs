using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IUnitofWork work;
        public AcountController(IUnitofWork _work)
        {
            work = _work;
        }
        [HttpPost("ManagerRegester")]
        public async Task<IActionResult> ManagerRegistration([FromForm] ManagerDto manager)
        {
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  
            var result= await work.authService.ManagerRegister(manager);
            if(!result.IsAuthenticated) { 
                return BadRequest(result.Message);  
            }
           
            return Ok(manager);
        }
        [HttpPost("MemberRegester")]
        public async Task<IActionResult> MemeberRegistration([FromForm] MemberDto member)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await work.authService.MemberRegister(member);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }

            return Ok(member);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDto manager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await work.authService.Login(manager);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(manager);
        }



    }
}
