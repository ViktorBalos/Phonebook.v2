using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetByID(int ID);
        void Insert(T entity);
        void Delete(int ID);
        void Update(T entity);
        void Save();
    }
}
