using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController: ControllerBase
    {
        readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) { _roleService = roleService; }

        [HttpGet("getroles")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAllRolesAsync());
        }

        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto dto)
        {
            try
            {
                await _roleService.CreateRole(dto);
            }
            catch (Exception ex) { return NotFound(ex.Message); }

            return Ok(dto);
        }

        [HttpGet("getrole/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await _roleService.GetRole(id);
            if(role == null) return NotFound();
            return Ok(role);
        }
        [HttpDelete("deleterole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
              await _roleService.DeleteRole(id);         
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }        
                return Ok();
        }

        [HttpPut("updaterole/{Id}")]
        public async Task<IActionResult> UpdateRole(int Id,UpdateRoleDto dto)
        {
            try
            {
                await _roleService.UpdateRole(Id, dto);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
            return Ok(dto);
        }

        [HttpPost("addemployeetorole/{id}/{employeId}")]
        public async Task<IActionResult> AddEmployeeToRole(int id, int employeId) 
        {
            try
            {
                await _roleService.AddEmployeeToRole(id, employeId);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
            return Ok();
        }

        [HttpPost("removeemployeefromrole/{id}/{employeId}")]
        public async Task<IActionResult> RemoveEmployeeFromRole(int id, int employeId)
        {
            try
            {
                await _roleService.RemoveEmployeeFromRole(id, employeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
