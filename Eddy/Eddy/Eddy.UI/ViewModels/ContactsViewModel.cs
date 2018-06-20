using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eddy.UI.ViewModels
{
    public class ContactsViewModel
    {
        public List<Shift> Schedule { get; set; }
        public Business PlaceOfBusiness { get; set; }
        public Person Person { get; set; }
    }
}
