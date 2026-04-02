using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
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