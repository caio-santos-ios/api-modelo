using SixLabors.ImageSharp;

namespace api_infor_cell.src.Handlers
{
    public class UploadHandler(IWebHostEnvironment env)
    {
        public async Task<string> UploadAttachment(string parent, IFormFile attachment)
        {
            string webRoot = Path.Combine(env.ContentRootPath, "wwwroot");
            string uploadPath = Path.Combine(webRoot, "uploads", parent);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string extension = Path.GetExtension(attachment.FileName).ToLower();
            string fileName = $"{Guid.NewGuid()}";
            
            bool isHeic = extension == ".heic" || extension == ".heif";
            string finalExtension = isHeic ? ".jpg" : extension;
            string filePath = Path.Combine(uploadPath, fileName + finalExtension);

            if (isHeic)
            {
                using (var inputStream = attachment.OpenReadStream())
                using (var image = await Image.LoadAsync(inputStream))
                {
                    await image.SaveAsJpegAsync(filePath);
                }
            }
            else
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await attachment.CopyToAsync(stream);
                }
            }

            return Path.Combine("uploads", parent, fileName + finalExtension).Replace("\\", "/");
        }
    }
}