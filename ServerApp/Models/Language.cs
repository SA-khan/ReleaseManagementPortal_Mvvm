using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Language
    {
        public long LanguageId { get; set; }
        public string Name { get; set; }
        [StringLength(2, ErrorMessage = "ISO2 standard allows only 2 characters.")]
        public string ISO2 { get; set; }
        [StringLength(3, ErrorMessage = "ISO3 standard allows only 3 characters.")]
        public string ISO3 { get; set; }
        public string Example { get; set; }
        public string Description { get; set; }
    }
}
