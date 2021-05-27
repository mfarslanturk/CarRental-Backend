using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataAccess.UploadFileTool.ImageFiles
{
    public class UploadPathFounder
    {
        

        public static async Task<string> CarImageSave(IFormFile imageFile)
        {
            var getExtension = Path.GetExtension(imageFile.FileName).ToLower();
            var imageName = DateTime.Now.ToString("yyyyMMMMdd")+"-" + Guid.NewGuid() + getExtension;
            var imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + FilePath.PathToUpload, imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            string imagePathAndName = "/image" + "/" + imageName;

            return imagePathAndName;
        }
    }
}
