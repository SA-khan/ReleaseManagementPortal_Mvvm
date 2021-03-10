using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Department
    {
        public long DepartmentId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string ShortName { get; set; }
        public long Code { get; set; }
        public string Comments { get; set; }
    }
}
