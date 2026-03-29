using System.Security.Claims;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_infor_cell.src.Controllers
{
    [Route("api/profile-users")]
    [ApiController]
    public class ProfileUserController(IProfileUserService service, ILoggerService loggerService) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            PaginationApi<List<dynamic>> response = await service.GetAllAsync(new(Request.Query));
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/profile-users",
                Method = "GET",
                Message = response.Message ?? "Perfis de usuário listados com sucesso",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            ResponseApi<dynamic?> response = await service.GetByIdAggregateAsync(id);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/profile-users/{id}",
                Method = "GET",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpGet("select")]
        public async Task<IActionResult> GetSelect()
        {
            ResponseApi<List<dynamic>> response = await service.GetSelectAsync(new(Request.Query));
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/profile-users/select",
                Method = "GET",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileUserDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos.");

            ResponseApi<ProfileUser?> response = await service.CreateAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/profile-users",
                Method = "POST",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProfileUserDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos.");

            ResponseApi<ProfileUser?> response = await service.UpdateAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/profile-users",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Result });
        }    
        
        [Authorize]
        [HttpGet("logged")]
        public async Task<IActionResult> GetLoggedAsync()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            ResponseApi<dynamic?> response = await service.GetLoggedAsync(userId!);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/profile-users/logged",
                Method = "GET",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Message, response.Result });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ResponseApi<ProfileUser> response = await service.DeleteAsync(new () { Id = id, DeletedBy = userId! });
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/profile-users/{id}",
                Method = "DELETE",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Result });
        }
    }
}