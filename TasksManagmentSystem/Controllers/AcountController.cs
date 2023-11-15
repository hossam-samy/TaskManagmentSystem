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
        [HttpPost("Regester")]
        public async Task<IActionResult> Registration([FromForm] RegesterDto manager)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  
            var result= await work.authService.Register(manager);
            if(!result.IsAuthenticated) { 
                return BadRequest(result.Message);  
            }
           
            return Ok(manager);
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
