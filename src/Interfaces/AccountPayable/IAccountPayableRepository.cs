using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.Utils;

namespace api_infor_cell.src.Interfaces
{
    public interface IAccountPayableRepository
    {
        Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<AccountPayable> pagination);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<AccountPayable?>> GetByIdAsync(string id);
        Task<int> GetCountDocumentsAsync(PaginationUtil<AccountPayable> pagination);
        Task<ResponseApi<AccountPayable?>> CreateAsync(AccountPayable accountPayable);
        Task<ResponseApi<AccountPayable?>> UpdateAsync(AccountPayable accountPayable);
        Task<ResponseApi<AccountPayable?>> PayAsync(AccountPayable accountPayable);
        Task<ResponseApi<AccountPayable>> DeleteAsync(string id);
    }
}
