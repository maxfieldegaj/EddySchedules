﻿using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eddy.UI.ViewModels
{
    public class ManagerNavBarViewModel
    {
        public ApplicationUser AppUser { get; set; }
        public Manager Manager { get; set; }
    }
}
