using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using api_infor_cell.src.Shared.Utils;

namespace api_infor_cell.src.Interfaces
{
public interface IProfileUserRepository
{
    Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<ProfileUser> pagination);
    Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
    Task<ResponseApi<ProfileUser?>> GetByIdAsync(string id);
    Task<ResponseApi<dynamic?>> GetLoggedAsync(string id);
    Task<ResponseApi<List<dynamic>>> GetSelectAsync(PaginationUtil<ProfileUser> pagination);
    Task<int> GetCountDocumentsAsync(PaginationUtil<ProfileUser> pagination);
    Task<ResponseApi<long>> GetNextCodeAsync(string planId, string companyId, string storeId);
    Task<ResponseApi<ProfileUser?>> CreateAsync(ProfileUser address);
    Task<ResponseApi<ProfileUser?>> UpdateAsync(ProfileUser address);
    Task<ResponseApi<ProfileUser>> DeleteAsync(DeleteDTO request);
}
}
