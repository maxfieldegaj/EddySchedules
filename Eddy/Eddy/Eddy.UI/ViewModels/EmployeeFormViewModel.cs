using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eddy.UI.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; }
        public Business PlaceOfBusiness { get; set; }
    }
}
