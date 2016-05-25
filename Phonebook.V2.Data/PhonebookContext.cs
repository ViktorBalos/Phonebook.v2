namespace Phonebook.V2.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhonebookContext : DbContext, IPhonebookContext
    {
        public PhonebookContext() : base("name=PhonebookContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Streets)
                .WithRequired(e => e.City)
                .HasForeignKey(c => c.CityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Country)
                .HasForeignKey(c => c.CountryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.Contacts)
                .WithRequired(e => e.Street)
                .HasForeignKey(s => s.StreetID)
                .WillCascadeOnDelete(false);
        }
    }
}
