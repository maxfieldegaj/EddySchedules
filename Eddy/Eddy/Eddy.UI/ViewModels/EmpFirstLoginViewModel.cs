using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eddy.UI.ViewModels
{
    public class EmpFirstLoginViewModel
    {
        public ApplicationUser AppUser { get; set; }
        public Employee Employee { get; set; }
    }
}
