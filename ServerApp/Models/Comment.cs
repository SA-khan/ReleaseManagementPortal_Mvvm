using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Comment
    {
        public long CommentId { get; set; }
        public Environment Environment { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public long Likes { get; set; }
    }
}
