using api_modelo.src.Models;

namespace api_modelo.src.Responses
{
    public class AuthResponse
    {
        public string Token {get;set;} = string.Empty; 
        public string RefreshToken  {get;set;} = string.Empty; 
    }
}