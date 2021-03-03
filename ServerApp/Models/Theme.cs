using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Theme
    {
        public long ThemeId { get; set; }
        public string ThemeCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
