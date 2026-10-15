using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
{
    public interface ISupplierService
    {
        Task<ResponseApi<PaginationApi<List<dynamic>>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<List<dynamic>>> GetAutocompleteAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(GetAllDTO request);
        Task<ResponseApi<Supplier?>> CreateAsync(CreateSupplierDTO request);
        Task<ResponseApi<Supplier?>> CreateMinimalAsync(CreateSupplierMinimalDTO request);
        Task<ResponseApi<Supplier?>> UpdateAsync(UpdateSupplierDTO request);
        Task<ResponseApi<Supplier>> DeleteAsync(string id);
    }
}