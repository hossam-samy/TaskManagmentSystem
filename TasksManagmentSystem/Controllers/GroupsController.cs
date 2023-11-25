using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;


namespace TasksManagmentSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IUnitofWork work;
        public GroupsController(IUnitofWork work)
        {
            this.work = work;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroup([FromForm]int id, [FromForm] GroupDto groupDto) {

            var group=work.groupRepo.Get(s=>s.Id==id).FirstOrDefault();   
            group.Name=groupDto.Name;   
            var result= await  work.groupRepo.Update(group);

            if (result == null) return BadRequest();
            
            return Ok(new {id,groupDto.Name });
            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGroup(int id) {
              
               var group=work.groupRepo.Get(s=>s.Id==id).FirstOrDefault();
               if(group==null) {
                 return NotFound();
                }
             work.groupRepo.Delete(group);
            return Ok("Succeeded");    
        }

        [HttpGet]
        public async  Task<IActionResult> ViewGroupsAsync(string id) {

            var groups = work.groupRepo.Get(b => b.Members.ToList().Find(s=>s.Id==id).Id==id,new[] { "Members","Projects", "manager" }).ToList();
            
            var result=new List<GroupResponseDto>();

            
            foreach (var item in groups)
            {
                var h = new GroupResponseDto(item.Projects.ToList(), item.Members.ToList()) { ManagerName = item.manager.UserName, Name = item.Name };
                if (h is not null)
                    result.Add(h);
               

            }
            var Members = result.Select(b=>b.Members.Select(s => new { s.UserName, s.Email })); 
            
            return Ok(result.Select(b => new {b.Name,b.ManagerName,Members,b.Projects }));
            //return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ViewAll()
        {
            var result = await work.groupRepo.ViewAll();
            
            return Ok(result);
            //return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult>CreateGroup([FromForm]GroupDto groupDto)
        {
            if(!ModelState.IsValid) {
             return BadRequest(ModelState);
            }
            var result = await work.groupRepo.Create(groupDto);   
            
            if(result is null )return BadRequest();

            
            return Ok(groupDto);  

        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromForm]string projectname, [FromForm] string groupname, [FromForm] string managerid)
        {
            if(!ModelState.IsValid) {
             return BadRequest(ModelState);
            }
            var result=await work.groupRepo.AddProject(projectname, groupname, managerid);  
            
            if(result is null )return BadRequest(); 
            

            return Ok("Succeded");  

        }
        [HttpPost]
        public async Task<IActionResult> AddMember([FromForm] string membername, [FromForm] string groupname, [FromForm] string managerid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await work.groupRepo.AddMember(membername, groupname, managerid);

            if (result is null) return BadRequest();


            return Ok("Succeded");

        }
    }
}
