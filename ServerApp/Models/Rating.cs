using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Rating
    {
        public long RatingId { get; set; }
        public User User { get; set; }
        public bool IsCompany { get; set; }
        public bool IsProduct { get; set; }
        public int Stars { get; set; }
        public Company Company { get; set; }
        public Product Product { get; set; }
    }
}
