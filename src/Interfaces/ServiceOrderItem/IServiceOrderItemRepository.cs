using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.Utils;

namespace api_modelo.src.Interfaces
{
public interface IServiceOrderItemRepository
{
    Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<ServiceOrderItem> pagination);
    Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
    Task<ResponseApi<ServiceOrderItem?>> GetByIdAsync(string id);
    Task<ResponseApi<List<ServiceOrderItem>>> GetByServiceOrderIdAsync(string serviceOrderId);
    Task<int> GetCountDocumentsAsync(PaginationUtil<ServiceOrderItem> pagination);
    Task<ResponseApi<ServiceOrderItem?>> CreateAsync(ServiceOrderItem address);
    Task<ResponseApi<ServiceOrderItem?>> UpdateAsync(ServiceOrderItem address);
    Task<ResponseApi<ServiceOrderItem>> DeleteAsync(string id);
}
}
