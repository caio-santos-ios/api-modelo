using api_infor_cell.src.Models.Base;

namespace api_infor_cell.src.Interfaces
{
    public interface IDreRepository
    {
        Task<ResponseApi<dynamic>> GenerateAsync(DateTime startDate, DateTime endDate, string regime);
    }
}