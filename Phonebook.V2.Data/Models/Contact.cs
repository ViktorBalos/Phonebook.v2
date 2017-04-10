namespace Phonebook.V2.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        public int StreetID { get; set; }

        [StringLength(10)]
        public string HouseNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime? CreatedOn { get; set; }       

        [StringLength(25)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; } 

        [StringLength(25)]
        public string UpdateBy { get; set; }


        public virtual Street Street { get; set; }
    }
}
