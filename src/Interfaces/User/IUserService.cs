using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Responses;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
{
    public interface IUserService
    {
        Task<ResponseApi<PaginationApi<List<dynamic>>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<dynamic?>> GetLoggedAsync(string id);
        Task<ResponseApi<User?>> CreateAsync(CreateUserDTO user);
        Task<ResponseApi<User?>> UpdateAsync(UpdateUserDTO user);
        Task<ResponseApi<AuthResponse?>> SavePhotoProfileTokenAsync(SaveUserPhotoDTO user);
        Task<ResponseApi<User?>> SavePhotoProfileAsync(SaveUserPhotoDTO user);
        Task<ResponseApi<User?>> ResendCodeAccessAsync(UpdateUserDTO user);
        Task<ResponseApi<User?>> RemovePhotoProfileAsync(string id);
        Task<ResponseApi<User?>> ValidatedAccessAsync(string codeAccess);
        Task<ResponseApi<User>> DeleteAsync(DeleteDTO request);
    }
}