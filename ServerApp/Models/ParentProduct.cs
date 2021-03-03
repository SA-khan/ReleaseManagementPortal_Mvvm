using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class ParentProduct
    {
        public long ParentProductId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public string UserManualLink { get; set; }
        public User MainPoc { get; set; }
        public string TeamName { get; set; }
        public int TeamQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Comments { get; set; }
    }
}
