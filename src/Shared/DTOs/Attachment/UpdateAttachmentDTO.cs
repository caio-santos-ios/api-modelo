namespace api_modelo.src.Shared.DTOs
{
    public class UpdateAttachmentDTO : RequestDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Uri { get; set; } = string.Empty;
        public IFormFile? File { get; set; }
        public string ParentId { get; set; } = string.Empty;
        public string Parent { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}