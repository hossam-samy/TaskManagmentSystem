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
        private readonly IUnitofWork unitofwork;
        //private readonly ibaserepo<manager> baserepo;

        public ManagersController(IUnitofWork unitofwork)
        {
            this.unitofwork = unitofwork;
            // this.baserepo = baserepo;
        }

        //[HttpGet("asd")]
        //public IActionResult getbyid(int id)
        //{
        //    //return ok(unitofwork.managers.get(b => b.id == id, b => new { b.name, b.email }));
        //   // return Ok(unitofwork.Managers.Get(b => b.Id == id, b => new { b.name, b.email }));
        //}
        [HttpGet("ofah")]
        public IActionResult getby(int id)
        {
            return Ok(unitofwork.Managers.Gets(id));
        }
    }
}
