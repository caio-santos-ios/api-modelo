using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
{
    public interface IProfileUserService
    {
        Task<PaginationApi<List<dynamic>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetLoggedAsync(string id);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(GetAllDTO request);
        Task<ResponseApi<ProfileUser?>> CreateAsync(CreateProfileUserDTO request);
        Task<ResponseApi<ProfileUser?>> UpdateAsync(UpdateProfileUserDTO request);
        Task<ResponseApi<ProfileUser>> DeleteAsync(string id);
    }
}