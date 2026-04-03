using api_infor_cell.src.Handlers;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using api_infor_cell.src.Shared.Utils;
using AutoMapper;

namespace api_infor_cell.src.Services
{
    public class DashboardService(IDashboardRepository repository) : IDashboardService
    {
        #region FINANCIAL
        public async Task<ResponseApi<dynamic>> GetAccountReceivable(DateTime startDate, DateTime endDate)
        {
            try
            {
                ResponseApi<dynamic> accountsReceivable = await repository.GetAccountReceivable(startDate, endDate);

                return new(accountsReceivable.Data, 200, "Contas a receber listados com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        public async Task<ResponseApi<dynamic>> GetAccountPayable(DateTime startDate, DateTime endDate)
        {
            try
            {
                ResponseApi<dynamic> accountsPayable = await repository.GetAccountPayable(startDate, endDate);

                return new(accountsPayable.Data, 200, "Contas a pagar listados com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        #endregion
    }
}
