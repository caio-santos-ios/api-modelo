using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_infor_cell.src.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController(IDashboardService service) : ControllerBase
    {
        [Authorize]
        [HttpGet("accounts-payable")]
        public async Task<IActionResult> GetAccountReceivable([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            ResponseApi<dynamic> response = await service.GetAccountReceivable(startDate, endDate);
            return StatusCode(response.StatusCode, new { response.Result });
        }
    }
}
