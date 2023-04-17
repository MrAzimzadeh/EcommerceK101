namespace EcommerceK101.Helpers
{
    public class ImageHelper
    {
        public static string UploadSinglePhoto(IFormFile file, IWebHostEnvironment env)
        {
            string folderName = "";
            file.ContentType.Contains("image");
            folderName = "Uploads";
            var path = "/" + folderName + "/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            using (var fileStream = new FileStream(env.WebRootPath + path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return path;
        }
    }
}
