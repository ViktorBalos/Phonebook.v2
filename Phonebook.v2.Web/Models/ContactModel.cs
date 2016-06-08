using System.ComponentModel;

namespace Phonebook.v2.Web.Models
{
    public class ContactModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}