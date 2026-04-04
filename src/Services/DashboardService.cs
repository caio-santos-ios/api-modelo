using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models.Base;
using AutoMapper;

namespace api_infor_cell.src.Services
{
    public class DashboardService(IDashboardRepository repository) : IDashboardService
    {
        #region FINANCIAL CARDS
        public async Task<ResponseApi<dynamic>> GetAccountReceivableCard(DateTime startDate, DateTime endDate)
        {
            try
            {
                ResponseApi<dynamic> accountsReceivable = await repository.GetAccountReceivableCard(startDate, endDate);

                return new(accountsReceivable.Data, 200, "Contas a receber listados com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        public async Task<ResponseApi<dynamic>> GetAccountPayableCard(DateTime startDate, DateTime endDate)
        {
            try
            {
                ResponseApi<dynamic> accountsPayable = await repository.GetAccountPayableCard(startDate, endDate);

                return new(accountsPayable.Data, 200, "Contas a pagar listados com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        public async Task<ResponseApi<dynamic>> GetCashFlowCard(DateTime startDate, DateTime endDate)
        {
            try
            {
                ResponseApi<dynamic> accountsPayable = await repository.GetCashFlowCard(startDate, endDate);

                return new(accountsPayable.Data, 200, "Fluxo de Caixa listados com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        #endregion
        #region FINANCIAL
        public async Task<ResponseApi<dynamic>> GetEntrieExitBar(DateTime startDate, DateTime endDate)
        {
            try
            {
                ResponseApi<dynamic> accountsReceivable = await repository.GetEntrieExitBar(startDate, endDate);

                return new(accountsReceivable.Data, 200, "Entradas VS Saidas listados com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        #endregion
    }
}
