using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Responses;
using api_infor_cell.src.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_infor_cell.src.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService service, ILoggerService loggerService) : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<AuthResponse> response = await service.LoginAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/auth/login",
                Method = "POST",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<dynamic> response = await service.RegisterAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/auth/register",
                Method = "POST",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPost]
        [Route("confirm-account")]
        public async Task<IActionResult> ConfirmAccountAsync([FromBody] ConfirmAccountDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<dynamic> response = await service.ConfirmAccountAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/auth/confirm-account",
                Method = "POST",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPost]
        [Route("new-code-confirm")]
        public async Task<IActionResult> NewCodeConfirmAsync([FromBody] NewCodeConfirmDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<dynamic> response = await service.NewCodeConfirmAsync(body);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/auth/new-code-confirm",
                Method = "POST",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpPut]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDTO request)
        {
            if (request == null) return BadRequest("Dados inválidos");

            ResponseApi<User> response = await service.ResetPasswordAsync(request);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/auth/reset-password",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPut]
        [Route("request-forgot-password")]
        public async Task<IActionResult> RequestForgotPasswordAsync([FromBody] ForgotPasswordDTO request)
        {
            if (request == null) return BadRequest("Dados inválidos");

            ResponseApi<User> response = await service.RequestForgotPasswordAsync(request);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/auth/request-forgot-password",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }

        [HttpPut]
        [Route("reset-forgot-password")]
        public async Task<IActionResult> ResetPassordForgotAsync([FromBody] ResetPasswordDTO request)
        {
            if (request == null) return BadRequest("Dados inválidos");

            ResponseApi<User> response = await service.ResetPassordForgotAsync(request);
            await loggerService.CreateAsync(new CreateLoggerDTO
            {
                Path = "/api/auth/reset-forgot-password",
                Method = "PUT",
                Message = response.Message ?? "",
                StatusCode = response.StatusCode
            });
            return StatusCode(response.StatusCode, new { response.Result });
        }
    }
}