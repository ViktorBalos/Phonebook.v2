using Phonebook.V2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {


        public void Delete(int ID)
        {
            T entity = PhonebookContext.T.Find(ID);
            PhonebookContext.T.Remove(entity);
        }

        public IEnumerable<T> Get()
        {
            return PhonebookContext.T.ToList();
        }

        public T GetByID(int ID)
        {
            return PhonebookContext.T.Find(ID);
        }

        public void Insert(T entity)
        {
            PhonebookContext.T.Add(entity);
        }

        public void Save()
        {
            PhonebookContext.SaveChanges();
        }

        public void Update(T entity)
        {
            PhonebookContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
