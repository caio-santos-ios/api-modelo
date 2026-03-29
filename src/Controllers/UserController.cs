using System.Security.Claims;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_infor_cell.src.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IUserService service, ILoggerService loggerService) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            PaginationApi<List<dynamic>> response = await service.GetAllAsync(new(Request.Query), userId);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users",
                Method = "GET",
                Message = response.Message ?? "Usuários listados com sucesso",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Message, response.Result });
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            ResponseApi<dynamic?> response = await service.GetByIdAggregateAsync(id);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users/{id}",
                Method = "GET",
                Message = response.Message ?? "Usuário obtido com sucesso",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO user)
        {
            if (user == null) return BadRequest("Dados inválidos.");

            ResponseApi<User?> response = await service.CreateAsync(user);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users",
                Method = "POST",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Message, response.Result });
        }
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO user)
        {
            if (user == null) return BadRequest("Dados inválidos.");

            ResponseApi<User?> response = await service.UpdateAsync(user);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Message, response.Result });
        }
        
        [HttpPut("code-access")]
        public async Task<IActionResult> ResendCodeAccess([FromBody] UpdateUserDTO user)
        {
            if (user == null) return BadRequest("Dados inválidos.");

            ResponseApi<User?> response = await service.ResendCodeAccessAsync(user);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users/code-access",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return response.IsSuccess ? Ok(new{response.Message}) : BadRequest(new{response.Message});
        }
        
        [HttpPut("confirm-access")]
        public async Task<IActionResult> ValidatedAccessAsync([FromBody] User user)
        {
            if (user == null) return BadRequest("Dados inválidos.");

            ResponseApi<User?> response = await service.ValidatedAccessAsync(user.CodeAccess);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users/confirm-access",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return response.IsSuccess ? Ok(new{response.Message}) : BadRequest(new{response.Message});
        }

        [Authorize]
        [HttpPut("profile-photo")]
        public async Task<IActionResult> SavePhotoProfileAsync([FromForm] SaveUserPhotoDTO user)
        {
            ResponseApi<User?> response = await service.SavePhotoProfileAsync(user);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users/profile-photo",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Message, response.Result });
        }
        
        [Authorize]
        [HttpDelete("remove-profile-photo/{id}")]
        public async Task<IActionResult> RemovePhotoProfileAsync(string id)
        {
            ResponseApi<User?> response = await service.RemovePhotoProfileAsync(id);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users/remove-profile-photo/{id}",
                Method = "DELETE",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return response.IsSuccess ? Ok(new{response.Message}) : BadRequest(new{response.Message});
        }
        
        [Authorize]
        [HttpGet("logged")]
        public async Task<IActionResult> GetLoggedAsync()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            ResponseApi<dynamic?> response = await service.GetLoggedAsync(userId!);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users/logged",
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
            ResponseApi<User> response = await service.DeleteAsync(new () { Id = id, DeletedBy = userId! });
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/users/{id}",
                Method = "DELETE",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode 
            });
            return StatusCode(response.StatusCode, new { response.Message });
        }
    }
}