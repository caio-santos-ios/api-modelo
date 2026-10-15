using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<ResponseApi<PaginationApi<List<dynamic>>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(GetAllDTO request);
        Task<ResponseApi<PaymentMethod?>> CreateAsync(CreatePaymentMethodDTO request);
        Task<ResponseApi<PaymentMethod?>> UpdateAsync(UpdatePaymentMethodDTO request);
        Task<ResponseApi<PaymentMethod>> DeleteAsync(string id);
    }
}