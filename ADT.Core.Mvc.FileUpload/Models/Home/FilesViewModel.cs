using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.FileUpload.Models.Home
{
    public class FilesViewModel
    {
        public List<FileDetails> Files { get; set; } = new List<FileDetails>();
    }

    public class FileDetails
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
