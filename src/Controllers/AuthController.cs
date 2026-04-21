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
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<AuthResponse> response = await service.LoginAsync(body);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<dynamic> response = await service.RegisterAsync(body);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPost]
        [Route("confirm-account")]
        public async Task<IActionResult> ConfirmAccountAsync([FromBody] ConfirmAccountDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<dynamic> response = await service.ConfirmAccountAsync(body);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPost]
        [Route("new-code-confirm")]
        public async Task<IActionResult> NewCodeConfirmAsync([FromBody] NewCodeConfirmDTO body)
        {
            if (body == null) return BadRequest("Dados inválidos");

            ResponseApi<dynamic> response = await service.NewCodeConfirmAsync(body);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpPut]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDTO request)
        {
            if (request == null) return BadRequest("Dados inválidos");

            ResponseApi<User> response = await service.ResetPasswordAsync(request);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [HttpPut]
        [Route("request-forgot-password")]
        public async Task<IActionResult> RequestForgotPasswordAsync([FromBody] ForgotPasswordDTO request)
        {
            if (request == null) return BadRequest("Dados inválidos");

            ResponseApi<User> response = await service.RequestForgotPasswordAsync(request);
            return StatusCode(response.StatusCode, new { response.Result });
        }

        [HttpPut]
        [Route("reset-forgot-password")]
        public async Task<IActionResult> ResetPassordForgotAsync([FromBody] ResetPasswordDTO request)
        {
            if (request == null) return BadRequest("Dados inválidos");

            ResponseApi<User> response = await service.ResetPassordForgotAsync(request);
            return StatusCode(response.StatusCode, new { response.Result });
        }
    }
}