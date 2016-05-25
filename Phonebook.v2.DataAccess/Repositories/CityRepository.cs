using Phonebook.V2.Data;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CityRepository : GenericRepository<City>
    {
        public CityRepository(IPhonebookContext context) : base(context)
        {
        }
    }
}
