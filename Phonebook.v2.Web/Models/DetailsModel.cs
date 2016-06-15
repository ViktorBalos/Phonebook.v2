using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phonebook.v2.Web.Models
{
    public class DetailsModel : ContactModel
    {
        public string StreetName { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }

        public string HouseNumber { get; set; }
        
        public DateTime? CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string UpdateBy { get; set; }

    }
}