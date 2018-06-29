using Eddy.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eddy.UI.ViewModels
{
    public class MgrFirstLoginViewModel
    {
        public ApplicationUser Manager { get; set; }
        public Business Business { get; set; }

        [Display(Name = "Check if creating a new business")]
        public bool NewBusiness { get; set; }

        public List<Business> AllBusinesses { get; set; }

    }
}
