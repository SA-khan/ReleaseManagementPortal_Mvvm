using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class EnvironmentTypeData
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public EnvironmentType EnvironmentType => new EnvironmentType
        {
            Name = Name,
            Description = Description
        };
    }
}
