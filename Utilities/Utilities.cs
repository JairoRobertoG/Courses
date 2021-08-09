using Microsoft.AspNetCore.Http;
using System.IO;

namespace Courses.Utilities
{
    public static class Utilities
    {
        public static bool IsImageProfileValidSize(long imageSize)
        {
            return (imageSize / 1024.0F / 1024.0F) < 1 ? true : false;
        }

        public static byte[] FiletoBytes(IFormFile formFile)
        {
            byte[] result = null;
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyToAsync(memoryStream);
                result = memoryStream.ToArray();
            };

            return result;
        }
    }
}
