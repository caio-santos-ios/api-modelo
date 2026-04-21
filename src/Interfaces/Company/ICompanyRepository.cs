using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using api_infor_cell.src.Shared.Utils;

namespace api_infor_cell.src.Interfaces
{
    public interface ICompanyRepository
    {
        Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<Company> pagination);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<Company?>> GetByIdAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(PaginationUtil<Company> pagination);
        Task<int> GetCountDocumentsAsync(PaginationUtil<Company> pagination);
        Task<ResponseApi<Company?>> CreateAsync(Company company);
        Task<ResponseApi<Company?>> UpdateAsync(Company company);
        Task<ResponseApi<Company>> DeleteAsync(DeleteDTO company);
    }
}
