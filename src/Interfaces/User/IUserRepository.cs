using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using api_infor_cell.src.Shared.Utils;

namespace api_infor_cell.src.Interfaces
{
    public interface IUserRepository
    {
        Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<User> pagination);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(PaginationUtil<User> pagination);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<dynamic?>> GetLoggedAsync(string id);
        Task<ResponseApi<User?>> GetByIdAsync(string id);
        Task<ResponseApi<User?>> GetByUserNameAsync(string userName);
        Task<ResponseApi<User?>> GetByEmailAsync(string email);
        Task<ResponseApi<User?>> GetByCodeAccessAsync(string codeAccess);
        Task<int> GetCountDocumentsAsync(PaginationUtil<User> pagination);
        Task<bool> GetAccessValitedAsync(string codeAccess);
        Task<ResponseApi<User?>> CreateAsync(User user);
        Task<ResponseApi<User?>> UpdateCodeAccessAsync(string userId, string codeAccess);
        Task<ResponseApi<User?>> UpdateAsync(User request);
        Task<ResponseApi<User?>> ValidatedAccessAsync(string codeAccess);
        Task<ResponseApi<User>> DeleteAsync(DeleteDTO request);
    }
}