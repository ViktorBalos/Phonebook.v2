using System.ComponentModel;

namespace Phonebook.v2.Web.Models
{
    public class ContactModel
    {
        [DisplayName("Identification Number")]
        public int ID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email Address")]
        public string Email { get; set; }

    }
}