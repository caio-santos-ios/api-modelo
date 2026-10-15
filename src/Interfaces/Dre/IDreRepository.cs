using api_modelo.src.Models.Base;

namespace api_modelo.src.Interfaces
{
    public interface IDreRepository
    {
        Task<ResponseApi<dynamic>> GenerateAsync(DateTime startDate, DateTime endDate, string regime);
    }
}