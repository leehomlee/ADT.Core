using Microsoft.AspNetCore.Http;

namespace ADT.Core.Mvc.FileUpload.Models.Home
{
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
