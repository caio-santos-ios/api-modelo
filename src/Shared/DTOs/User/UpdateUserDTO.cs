namespace api_infor_cell.src.Shared.DTOs
{
    public class UpdateUserDTO : RequestDTO
    {
        public string Id { get; set; } = string.Empty;
        public string ProfileUserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Admin { get; set; } = false;
        public bool Blocked { get; set; } = false;
        public List<ModuleCreateDTO> Modules {get;set;} = [];
        public DateTime? EffectiveDate { get; set; }
    }
}