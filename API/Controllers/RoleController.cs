using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {

            var id = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id }, dto);

        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _service.GetByIdAsync(id);
            return role == null ? NotFound() : Ok(role);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto dto)
        {

            await _service.UpdateAsync(id, dto);

            return NoContent();

        }

        [Authorize]
        [HttpPost("{id:int}/employees{employeId:int}")]
        public async Task<IActionResult> AddEmployee(int id, int employeId)
        {

            await _service.AddEmployeeAsync(id, employeId);

            return NoContent();


        }

        [Authorize]
        [HttpDelete("{id:int}/employees{employeId:int}")]
        public async Task<IActionResult> RemoveEmployee(int id, int employeId)
        {
            await _service.RemoveEmployeeAsync(id, employeId);
            return NoContent();
        }
    }
}
