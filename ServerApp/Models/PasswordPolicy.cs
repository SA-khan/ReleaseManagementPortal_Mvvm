using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class PasswordPolicy
    {
        public long PasswordPolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CapitalLetter { get; set; }
        public long SmallLetter { get; set; }
        public long Number { get; set; }
        public long SpecialLetter { get; set; }
        public string Example { get; set; }
        public string Comments { get; set; }
    }
}
