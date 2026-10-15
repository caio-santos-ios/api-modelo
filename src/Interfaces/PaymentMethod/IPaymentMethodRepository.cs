using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.Utils;

namespace api_modelo.src.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<PaymentMethod> pagination);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<PaymentMethod?>> GetByIdAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(PaginationUtil<PaymentMethod> pagination);
        Task<int> GetCountDocumentsAsync(PaginationUtil<PaymentMethod> pagination);
        Task<ResponseApi<PaymentMethod?>> CreateAsync(PaymentMethod address);
        Task<ResponseApi<PaymentMethod?>> UpdateAsync(PaymentMethod address);
        Task<ResponseApi<PaymentMethod>> DeleteAsync(string id);
    }
}
