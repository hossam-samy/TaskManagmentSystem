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
        public IActionResult Registration ([FromForm]ManagerRegesterDto manager)
        {
            work.Managers.Register(new(manager));
            return Ok(manager);
        }
        [HttpPost("Login")]

        public IActionResult Login([FromForm] ManagerLoginDto manager) {

            var found = work.Managers.Get(b => 
            b.Name == manager.Name && b.Password == manager.Password,b=> new Manager());
            if(found != null) 
            return Ok(true);

            return BadRequest();    
            
        }
    }
}
