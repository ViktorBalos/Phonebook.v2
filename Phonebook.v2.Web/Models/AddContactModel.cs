using Phonebook.V2.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learn.Phonebook.Web.Models.Data
{
    public class AddContactModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string StreetName { get; set; }

        [StringLength(10)]
        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "City")]
        public string CityName { get; set; }

        //public Countries Country { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        public IEnumerable<Country> Countries { get; set; }
    }
}
