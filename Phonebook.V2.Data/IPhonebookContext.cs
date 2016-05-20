using System.Data.Entity;

namespace Phonebook.V2.Data
{
    public interface IPhonebookContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Street> Streets { get; set; }
    }
}