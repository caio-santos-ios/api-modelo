using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
{
    public interface IAccountPayableService
    {
        Task<PaginationApi<List<dynamic>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<AccountPayable?>> CreateAsync(CreateAccountPayableDTO request);
        Task<ResponseApi<AccountPayable?>> UpdateAsync(UpdateAccountPayableDTO request);
        Task<ResponseApi<AccountPayable?>> PayAsync(PayAccountPayableDTO request);
        Task<ResponseApi<AccountPayable>> DeleteAsync(string id);
    }
}
