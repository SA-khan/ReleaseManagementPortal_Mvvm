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
        public string Description { get; set; }
        public Product Product { get; set; }
        public string TagLine { get; set; }
        public Environment Environment { get; set; }
        public List<Database> Databases { get; set; }
        public List<Api> Apis { get; set; }
        public bool Main { get; set; }
        public string Comments { get; set; }

    }
}
