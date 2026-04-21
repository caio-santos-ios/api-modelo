using api_infor_cell.src.Models;

namespace api_infor_cell.src.Responses
{
    public class AuthResponse
    {
        public string Token {get;set;} = string.Empty; 
        public string RefreshToken  {get;set;} = string.Empty; 
    }
}