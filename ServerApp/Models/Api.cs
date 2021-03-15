using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Api
    {
        public long ApiId { get; set; }
        public string Name { get; set; }
        public string FolderHash { get; set; }
        public string Url { get; set; }
        public string DirectoryLocation { get; set; }
        public Product Description { get; set; }
        public string TagLine { get; set; }
        public Environment Environment { get; set; }
        public bool Main { get; set; }
        public string Comments { get; set; }

    }
}
