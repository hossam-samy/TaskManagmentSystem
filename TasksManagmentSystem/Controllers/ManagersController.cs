using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;
using TasksManagmentSystem.EF;

namespace TasksManagmentSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class ManagersController : ControllerBase
    {
        private readonly IUnitofWork work;


        public ManagersController(IUnitofWork work)
        {
            this.work = work;
         
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mangers = await work.managerRepo.GetAll();
            
            return Ok(mangers.Select(b => new {b.FirstName,b.LastName,b.UserName,b.Email }));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateManager([FromForm]string id,[FromForm]ManagerDto input) {
          var manager=work.managerRepo.Get(b=>b.Id==id).FirstOrDefault();
            if (manager == null) {return NotFound();}
            if (manager.UserName is not null)
                manager.UserName = input.UserName;

            if (manager.Email is not null)
                manager.Email = input.Email;

            if (manager.PhoneNumber is not null)
                manager.PhoneNumber = input.Phone;

            if (manager.FirstName is not null)
                manager.FirstName = input.FirstName;
            if (manager.LastName is not null)
                manager.LastName = input.LastName;
            
            
            var result = await work.managerRepo.Update(manager);
            return Ok(input);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteManager(string id)
        {
            var manager=work.managerRepo.Get(b=>b.Id== id).FirstOrDefault(); 
            if (manager == null) { return NotFound();}
            var result = new ManagerDto(manager);

             work.managerRepo.Delete(manager);
            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> Assign([FromForm]string id,[FromForm]TaskDto input, [FromForm] string managerid) {
            
            var h=await work.managerRepo.AssignTask(id,managerid,input); 
            return Ok(h);    
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromForm] int id,[FromForm]TaskDto dto)
        {
            DateTime unused=new();
            var task= work.Tasks.Get(b=>b.Id==id).FirstOrDefault();
            if (task == null) { return NotFound(); }
            if (task.EndDate!= null)
                task.EndDate =(DateTime) dto.EndDate;
            

            if (task.StartDate != null)
                task.StartDate = (DateTime)dto.StartDate;

            if (task.Status is not null)
                task.Status = dto.Status;

            if (task.Description is not null)
                task.Description = dto.Description;
           
            var result=await work.Tasks.Update(task);

            return Ok(new TaskDto { Description=result.Description, EndDate=result.EndDate, StartDate=result.StartDate, Status=result.Status });    
        }

    }
}
