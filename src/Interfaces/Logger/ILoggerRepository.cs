using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;
using api_modelo.src.Shared.Utils;

namespace api_modelo.src.Interfaces
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
