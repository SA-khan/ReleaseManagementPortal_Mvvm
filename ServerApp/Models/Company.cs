using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string TagLine { get; set; }
        public Industry Industry { get; set; }
        public string Logo { get; set; }
        public string Ntn { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website  { get; set; }
        public List<Rating> Ratings { get; set; }
        public bool Still { get; set; }
        public User TechnicalPoc { get; set; }
        public User OperationalPoc { get; set; }
        public User ProjectPoc { get; set; }
        public User FinancialPoc { get; set; }
        public List<CompanyFinancial> Financials { get; set; }
        public string Comments { get; set; }
    }
}
