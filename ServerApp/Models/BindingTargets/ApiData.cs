using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class ApiData
    {
        [Required]
        public string Name { 
            get => Api.Name ?? null; 
            set => Api.Name = value;
        }
        public string FolderHash { 
            get => Api.FolderHash ?? null; 
            set => Api.FolderHash = value; 
        }
        public string Url { 
            get => Api.Url ?? null; 
            set => Api.Url = value; 
        }
        public string DirectoryLocation { 
            get => Api.DirectoryLocation ?? null; 
            set => Api.DirectoryLocation = value; 
        }
        public string Description { 
            get => Api.Description ?? null; 
            set => Api.Description = value; 
        }
        public long? Product { 
            get => Api.Product?.ProductId ?? null; 
            set
            {
                if (!value.HasValue)
                {
                    Api.Product = null;
                }
                else
                {
                    if(Api.Product == null)
                    {
                        Api.Product = new Product();
                    }
                    Api.Product.ProductId = value.Value;
                }
            } 
        }
        public string TagLine { 
            get => Api.TagLine ?? null; 
            set => Api.TagLine = value; 
        }
        public long? Environment { 
            get => Api.Environment?.EnvironmentId ?? null; 
            set
            {
                if (!value.HasValue)
                {
                    Api.Environment = null;
                }
                else
                {
                    if(Api.Environment == null)
                    {
                        Api.Environment = new Environment();
                    }
                    Api.Environment.EnvironmentId = value.Value;
                }
            } 
        }
        public List<Database> Databases { get; set; }
        public List<Api> Apis { get; set; }
        public bool Main { 
            get => Api.Main; 
            set => Api.Main = value; 
        }
        public string Comments { 
            get => Api.Comments ?? null; 
            set => Api.Comments = value; 
        }
        public Api Api { get; set; } = new Api();   
            
    }
}

