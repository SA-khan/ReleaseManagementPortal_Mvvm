using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class EnvironmentTypeData
    {
        public string Name { 
            get => EnvironmentType.Name; 
            set => EnvironmentType.Name = value; 
        }

        public string Logo { 
            get => EnvironmentType.Logo; 
            set => EnvironmentType.Logo = value; 
        }
        public string ShortName { 
            get => EnvironmentType.ShortName; 
            set => EnvironmentType.ShortName = value; 
        }
        public string Description { 
            get => EnvironmentType.Description; 
            set => EnvironmentType.Description = value; 
        }
        public EnvironmentType EnvironmentType { get; set; } = new EnvironmentType();
    }
}
