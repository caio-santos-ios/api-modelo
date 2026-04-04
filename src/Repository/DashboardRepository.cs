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
        #region FINANCIAL CARDS
        public async Task<ResponseApi<dynamic>> GetAccountReceivableCard(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<AccountReceivable> openAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Recebido Parcial")).ToListAsync();
                decimal openAmount = openAmountList.Sum(x => x.Amount) - openAmountList.Sum(x => x.AmountPaid);

                long openCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Recebido Parcial")).CountDocumentsAsync();
                
                List<AccountReceivable> cancelAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").ToListAsync();
                decimal cancelAmount = cancelAmountList.Sum(x => x.Amount);

                long cancelCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").CountDocumentsAsync();
                
                List<AccountReceivable> overdueAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").ToListAsync();
                decimal overdueAmount = overdueAmountList.Sum(x => x.Amount) - overdueAmountList.Sum(x => x.AmountPaid);

                long overdueCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").CountDocumentsAsync();
                
                List<AccountReceivable> totalAmountList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date).ToListAsync();
                decimal totalAmount = totalAmountList.Sum(x => x.Amount);

                long totalCount = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date).CountDocumentsAsync();
                
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
        public async Task<ResponseApi<dynamic>> GetAccountPayableCard(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<AccountPayable> openAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Pago Parcial")).ToListAsync();
                decimal openAmount = openAmountList.Sum(x => x.Amount) - openAmountList.Sum(x => x.AmountPaid);

                long openCount = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Em Aberto" || x.Status == "Pago Parcial")).CountDocumentsAsync();
                
                List<AccountPayable> cancelAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").ToListAsync();
                decimal cancelAmount = cancelAmountList.Sum(x => x.Amount);

                long cancelCount = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status == "Cancelado").CountDocumentsAsync();
                
                List<AccountPayable> overdueAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").ToListAsync();
                decimal overdueAmount = overdueAmountList.Sum(x => x.Amount) - overdueAmountList.Sum(x => x.AmountPaid);

                long overdueCount = await context.AccountsPayable.Find(x => !x.Deleted && x.DueDate.Date < DateTime.UtcNow.Date && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && x.Status != "Cancelado").CountDocumentsAsync();
                
                List<AccountPayable> totalAmountList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date).ToListAsync();
                decimal totalAmount = totalAmountList.Sum(x => x.Amount);

                long totalCount = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date).CountDocumentsAsync();
                
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
        public async Task<ResponseApi<dynamic>> GetCashFlowCard(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<AccountReceivable> entriesList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Recebido" || x.Status == "Recebido Parcial")).ToListAsync();
                decimal entrieTotal = entriesList.Where(x => x.Status == "Recebido").Sum(x => x.Amount);
                decimal entriePartial = entriesList.Where(x => x.Status == "Recebido Parcial").Sum(x => x.AmountPaid);
                
                List<AccountPayable> exitsList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Pago" || x.Status == "Pago Parcial")).ToListAsync();
                decimal exitTotal = exitsList.Where(x => x.Status == "Pago").Sum(x => x.Amount);
                decimal exitPartial = exitsList.Where(x => x.Status == "Pago Parcial").Sum(x => x.AmountPaid);
                
                decimal entries = entrieTotal + entriePartial;
                decimal exits = exitTotal + exitPartial;

                dynamic data = new
                {
                    entries,
                    exits,
                    balance = entries - exits
                };

                return new(data);
            }
            catch
            {
                return new(null, 500, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
            }
        }
        #endregion
        #region FINANCIAL BARS
        public async Task<ResponseApi<dynamic>> GetEntrieExitBar(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<AccountReceivable> entrieList = await context.AccountsReceivable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Recebido" || x.Status == "Recebido Parcial")).ToListAsync();

                List<AccountReceivable> entrieValueList = [];
                foreach (AccountReceivable entrie in entrieList)
                {
                    if(entrie.Status == "Recebido") 
                    {
                        entrieValueList.Add(entrie);
                    }
                    else
                    {
                        entrie.Amount = entrie.AmountPaid; 
                        entrieValueList.Add(entrie);
                    }
                }

                var entries = entrieValueList
                .GroupBy(x => new { x.IssueDate.Year, x.IssueDate.Month })
                .Select(g => g.Sum(x => x.Amount))
                .ToList();
                
                List<AccountPayable> exitList = await context.AccountsPayable.Find(x => !x.Deleted && x.IssueDate.Date >= startDate.Date && x.IssueDate.Date <= endDate.Date && (x.Status == "Pago" || x.Status == "Pago Parcial")).ToListAsync();

                List<AccountPayable> exitValueList = [];
                foreach (AccountPayable exit in exitList)
                {
                    if(exit.Status == "Pago") 
                    {
                        exitValueList.Add(exit);
                    }
                    else
                    {
                        exit.Amount = exit.AmountPaid; 
                        exitValueList.Add(exit);
                    }
                }

                var exits = exitValueList
                .GroupBy(x => new { x.IssueDate.Year, x.IssueDate.Month })
                .Select(g => g.Sum(x => x.Amount))
                .ToList();


                dynamic data = new
                {
                    entries,
                    exits,
                    categories = GenerateMonths(startDate, endDate)
                };

                return new(data);
            }
            catch
            {
                return new(null, 500, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
            }
        }
        #endregion
        #region FUNCTIONS
        private List<string> GenerateMonths(DateTime startDate, DateTime endDate)
        {
            List<string> months = new();

            DateTime controlDate = startDate;

            while(controlDate < endDate)
            {
                controlDate = controlDate.AddMonths(1);
                months.Add(controlDate.ToString("MM/yy"));
            }

            return months;
        }
        #endregion
    }
}
