using System.Security.Claims;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_infor_cell.src.Controllers
{
    [Route("api/templates")]
    [ApiController]
    public class TemplateController(ITemplateService service, ILoggerService loggerService) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            PaginationApi<List<dynamic>> response = await service.GetAllAsync(new(Request.Query));
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/templates",
                Method = "GET",
                Message = response.Message ?? "Templates listados com sucesso",
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
                Path = "/api/templates/{id}",
                Method = "GET",
                Message = response.Message ?? "Perfil de usuário obtido com sucesso",
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
                Path = "/api/templates/select",
                Method = "GET",
                Message = response.Message ?? "Templates listados com sucesso",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTemplateDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos.");

            ResponseApi<Template?> response = await service.CreateAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/templates",
                Method = "POST",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTemplateDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos.");

            ResponseApi<Template?> response = await service.UpdateAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/templates",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Result });
        }    
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ResponseApi<Template> response = await service.DeleteAsync(new () { Id = id, DeletedBy = userId! });
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/templates/{id}",
                Method = "DELETE",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });

            return StatusCode(response.StatusCode, new { response.Result });
        }
    }
}