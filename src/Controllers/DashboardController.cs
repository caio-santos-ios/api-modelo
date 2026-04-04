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
        [HttpGet("accounts-receivable")]
        public async Task<IActionResult> GetAccountReceivableCard([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            ResponseApi<dynamic> response = await service.GetAccountReceivableCard(startDate, endDate);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpGet("accounts-payable")]
        public async Task<IActionResult> GetAccountPayableCard([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            ResponseApi<dynamic> response = await service.GetAccountPayableCard(startDate, endDate);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpGet("cash-flow")]
        public async Task<IActionResult> GetCashFlowCard([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            ResponseApi<dynamic> response = await service.GetCashFlowCard(startDate, endDate);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpGet("entrie-exit")]
        public async Task<IActionResult> GetEntrieExitBar([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            ResponseApi<dynamic> response = await service.GetEntrieExitBar(startDate, endDate);
            return StatusCode(response.StatusCode, new { response.Result });
        }
        
        [Authorize]
        [HttpGet("expense-category")]
        public async Task<IActionResult> GetExpenseCategoryPie([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            ResponseApi<dynamic> response = await service.GetExpenseCategoryPie(startDate, endDate);
            return StatusCode(response.StatusCode, new { response.Result });
        }
    }
}
