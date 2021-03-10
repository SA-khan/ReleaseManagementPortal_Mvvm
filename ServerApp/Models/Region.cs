using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Region
    {
        public long RegionId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        [StringLength(2, ErrorMessage = "ISO2 standard only support 2 charactors")]
        public string ISO2 { get; set; }
        [StringLength(3, ErrorMessage = "ISO3 standard only support 3 charactors")]
        public string ISO3 { get; set; }
        public string OfficialName { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Longitude { get; set; }
    }
}
