using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Phonebook.V2.Data
{
    public interface IPhonebookContext
    {
        DbSet<T> Set<T>() where T: class;
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}