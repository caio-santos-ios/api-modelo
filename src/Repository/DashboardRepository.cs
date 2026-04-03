using api_infor_cell.src.Configuration;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace api_infor_cell.src.Repository
{
    public class DashboardRepository(AppDbContext context) : IDashboardRepository
    {
        #region FINANCIAL
        public async Task<ResponseApi<dynamic>> GetAccountReceivable(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<AccountReceivable> openAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Recebido Parcial")).ToListAsync();
                decimal openAmount = openAmountList.Sum(x => x.Amount);

                long openCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Recebido Parcial")).CountDocumentsAsync();
                
                List<AccountReceivable> cancelAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").ToListAsync();
                decimal cancelAmount = cancelAmountList.Sum(x => x.Amount);

                long cancelCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").CountDocumentsAsync();
                
                List<AccountReceivable> overdueAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").ToListAsync();
                decimal overdueAmount = overdueAmountList.Sum(x => x.Amount) - overdueAmountList.Sum(x => x.AmountPaid);

                long overdueCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").CountDocumentsAsync();
                
                List<AccountReceivable> totalAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date).ToListAsync();
                decimal totalAmount = totalAmountList.Sum(x => x.Amount);

                long totalCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date).CountDocumentsAsync();
                
                dynamic data = new
                {
                    openAmount,
                    openCount,
                    overdueAmount,
                    overdueCount,
                    cancelAmount,
                    cancelCount,
                    totalAmount,
                    totalCount
                };

                return new(data);
            }
            catch
            {
                return new(null, 500, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
            }
        }
        public async Task<ResponseApi<dynamic>> GetAccountPayable(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<AccountPayable> openAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Recebido Parcial")).ToListAsync();
                decimal openAmount = openAmountList.Sum(x => x.Amount);

                long openCount = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Recebido Parcial")).CountDocumentsAsync();
                
                List<AccountPayable> cancelAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").ToListAsync();
                decimal cancelAmount = cancelAmountList.Sum(x => x.Amount);

                long cancelCount = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").CountDocumentsAsync();
                
                List<AccountPayable> overdueAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").ToListAsync();
                decimal overdueAmount = overdueAmountList.Sum(x => x.Amount) - overdueAmountList.Sum(x => x.AmountPaid);

                long overdueCount = await context.AccountsPayable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").CountDocumentsAsync();
                
                List<AccountPayable> totalAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date).ToListAsync();
                decimal totalAmount = totalAmountList.Sum(x => x.Amount);

                long totalCount = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date.AddDays(-1) && x.IssueDate.Date <= endDate.Date).CountDocumentsAsync();
                
                dynamic data = new
                {
                    openAmount,
                    openCount,
                    overdueAmount,
                    overdueCount,
                    cancelAmount,
                    cancelCount,
                    totalAmount,
                    totalCount
                };

                return new(data);
            }
            catch
            {
                return new(null, 500, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
            }
        }
        #endregion
    }
}
