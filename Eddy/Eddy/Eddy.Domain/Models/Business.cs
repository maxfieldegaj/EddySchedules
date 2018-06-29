using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eddy.Domain.Models
{
    public class Business
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Business Name Required")]
        public string Name { get; set; }


        public string StreetNumber { get; set; }

        public string StreetName { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "City Name Required")]
        public string City { get; set; }

        [StringLength (20, MinimumLength = 4)]
        [Required(ErrorMessage ="State Name Required")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 5)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")]
        [Required(ErrorMessage = "Zip Code is Required.")]
        public string ZipCode { get; set; }

        public List<Business> AffiliatedBusinesses { get; set; }
        public string PhoneNumber { get; set; }
        public List<Shift> Schedule { get; set; }
        public List<Employee> Staff { get; set; }
        public List<Manager> Managers { get; set; }
    }
}
