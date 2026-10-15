using api_modelo.src.Models.Base;

namespace api_modelo.src.Interfaces
{
    public interface IDreService
    {
        Task<ResponseApi<dynamic?>> GenerateAsync(DateTime startDate, DateTime endDate, string regime);
    }
}