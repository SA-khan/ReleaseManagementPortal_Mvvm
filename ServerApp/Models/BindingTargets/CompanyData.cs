using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class CompanyData
    {
        [Required]
        public string Name { 
            get => Name;
            set => Name = value;
        }

        public string TagLine {
            get => TagLine;
            set => TagLine = value;
        }
        [Required]
        public long Industry {
            get => Industry;
            set => Industry = value;
        }
        public string Logo {
            get => Logo;
            set => Logo = value;
        }
        public string Ntn {
            get => Ntn;
            set => Ntn = value;
        }
        public string Email {
            get => Email;
            set => Email = value;
        }
        public string Phone {
            get => Phone;
            set => Phone = value;
        }
        public string Fax {
            get => Fax;
            set => Fax = value;
        }
        public string Website {
            get => Website;
            set => Website = value;
        }
        public bool Still {
            get => Still;
            set => Still = value;
        }
        public long TechnicalPoc {
            get => TechnicalPoc;
            set => TechnicalPoc = value;
        }
        public long OperationalPoc {
            get => OperationalPoc;
            set => OperationalPoc = value;
        }
        public long ProjectPoc {
            get => ProjectPoc;
            set => ProjectPoc = value;
        }
        public long FinancialPoc {
            get => FinancialPoc;
            set => FinancialPoc = value;
        }
        public string Comments {
            get => Comments;
            set => Comments = value;
        }

        //public Company Company => new Company { 
        //    Name = Name, TagLine = TagLine, Logo = Logo,
        //    Ntn = Ntn, Email = Email, Phone = Phone, Fax = Fax, Website = Website,
        //    Still = Still, Comments = Comments
        //};
        public Company Company = new Company { };
        

    }
}
