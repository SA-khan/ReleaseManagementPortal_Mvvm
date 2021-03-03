using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Question
    {
        public long QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
