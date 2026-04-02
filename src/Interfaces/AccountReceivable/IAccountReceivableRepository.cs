using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.Utils;

namespace api_infor_cell.src.Interfaces
{
    public interface IAccountReceivableRepository
    {
        Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<AccountReceivable> pagination);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<AccountReceivable?>> GetByIdAsync(string id);
        Task<int> GetCountDocumentsAsync(PaginationUtil<AccountReceivable> pagination);
        Task<ResponseApi<AccountReceivable?>> CreateAsync(AccountReceivable accountReceivable);
        Task<ResponseApi<AccountReceivable?>> UpdateAsync(AccountReceivable accountReceivable);
        Task<ResponseApi<AccountReceivable?>> PayAsync(AccountReceivable accountReceivable);
        Task<ResponseApi<AccountReceivable>> DeleteAsync(string id);
    }
}
