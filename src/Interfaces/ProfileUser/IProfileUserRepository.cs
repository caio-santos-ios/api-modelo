using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;
using api_modelo.src.Shared.Utils;

namespace api_modelo.src.Interfaces
{
public interface IProfileUserRepository
{
    Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<ProfileUser> pagination);
    Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
    Task<ResponseApi<ProfileUser?>> GetByIdAsync(string id);
    Task<ResponseApi<List<dynamic>>> GetSelectAsync(PaginationUtil<ProfileUser> pagination);
    Task<int> GetCountDocumentsAsync(PaginationUtil<ProfileUser> pagination);
    Task<ResponseApi<ProfileUser?>> CreateAsync(ProfileUser address);
    Task<ResponseApi<ProfileUser?>> UpdateAsync(ProfileUser address);
    Task<ResponseApi<ProfileUser>> DeleteAsync(DeleteDTO request);
}
}
