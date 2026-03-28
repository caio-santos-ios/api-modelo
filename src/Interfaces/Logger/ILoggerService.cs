using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
{
    public interface ILoggerService
    {
        Task<PaginationApi<List<dynamic>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<Logger?>> CreateAsync(CreateLoggerDTO request);
        Task<ResponseApi<Logger?>> UpdateAsync(UpdateLoggerDTO request);
        Task<ResponseApi<Logger>> DeleteAsync(DeleteDTO request);
    }
}