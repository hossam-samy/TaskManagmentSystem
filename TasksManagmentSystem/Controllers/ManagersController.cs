using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;
using TasksManagmentSystem.EF;

namespace TasksManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManagersController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        //private readonly IBaseRepo<Manager> baseRepo;

        public ManagersController(IUnitofWork unitofWork)
        {
           this.unitofWork = unitofWork;
           // this.baseRepo = baseRepo;
        }
        
        [HttpGet("asd")]
        public IActionResult getbyid(int id)
        {
            //return Ok(unitofWork.Managers.Get(b => b.Id == id, b => new { b.Name, b.Email }));
            return Ok(unitofWork.Managers.Get(b => b.Id == id, b => new {b.Name,b.Email}));    
        }
        [HttpGet("ofah")]
        public IActionResult getby(int id)
        {
            return Ok(unitofWork.Managers.Gets(id));
        }
    }
}
