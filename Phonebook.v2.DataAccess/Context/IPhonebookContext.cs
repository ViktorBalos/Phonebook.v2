using Phonebook.V2.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Phonebook.V2.DataAccess
{
    public interface IPhonebookContext
    {
        DbSet<T> Set<T>() where T: class;
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        void Dispose();

        DbSet<City> Cities { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Street> Streets { get; set; }
    }
}