using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        { 
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDto dto)
        {

             var id =  await _service.CreateAsync(dto);
            
             return CreatedAtAction(nameof(Get), new {id},dto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var department = await _service.GetByIdAsync(id);
            return department == null ? NotFound() : Ok(department);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartmentDto dto)
        {
          
            await _service.UpdateAsync(id, dto);

            return NoContent();
                  
        }

        [HttpPost("{id:int}/employees{employeId:int}")]
        public async Task<IActionResult> AddEmployeeToRole(int id, int employeId)
        {
           
           await _service.AddEmployeeAsync(id, employeId);
               
            return NoContent();
            
            
        }
        [HttpDelete("{id:int}/employees{employeId:int}")]
        public async Task<IActionResult> RemoveEmployeeFromDepartment(int id, int employeId)
        {
            await _service.RemoveEmployeeAsync(id,employeId);
            return NoContent();
        }
    }
}
