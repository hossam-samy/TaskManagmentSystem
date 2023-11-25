using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       private readonly IUnitofWork work;
        public HomeController(IUnitofWork work)
        {
            this.work = work;   
        }

        [HttpGet]

        public async Task<IActionResult> ViewAllAsync() {

            return Ok(work.projectRepo.Get(b => new { b.Name, b.Status, b.manager.Email }, "manager")); 
                    
        }


        [HttpPost]
        public IActionResult CreateProject([FromForm]ProjectDto input,[FromForm] string id)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState); 
            }
           var result= work.projectRepo.Write(input,id);   
            if(result== "Project name should be uniqe")
                return BadRequest(result);
           
            return Ok(result);  
        }
        [HttpPut]
        public async Task<IActionResult>UpdateProject([FromForm]ProjectDto model,[FromForm]int id)
        {
            if(!ModelState.IsValid) { 
              return BadRequest(ModelState);  
            }
            
            
            var project = work.projectRepo.Get(b => b.Id == id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            
            }


                project.Name = model.Name;
                project.Status = model.Status;
            work.projectRepo.Update(project);  
           

            return Ok(model);


        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {

            var project = work.projectRepo.Get(s => s.Id == id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            }
            work.projectRepo.Delete(project);
            return Ok("Succeeded");
        }

    }
}
