namespace api_infor_cell.src.Shared.DTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool PrivacyPolicy { get; set; } = false;
    }
}