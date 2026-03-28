using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using api_infor_cell.src.Shared.Utils;

namespace api_infor_cell.src.Interfaces
{
    public interface ILoggerRepository
    {
        Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<Logger> pagination);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<Logger?>> GetByIdAsync(string id);
        Task<int> GetCountDocumentsAsync(PaginationUtil<Logger> pagination);
        Task<ResponseApi<Logger?>> CreateAsync(Logger logger);
        Task<ResponseApi<Logger?>> UpdateAsync(Logger logger);
        Task<ResponseApi<Logger>> DeleteAsync(DeleteDTO request);
    }
}
