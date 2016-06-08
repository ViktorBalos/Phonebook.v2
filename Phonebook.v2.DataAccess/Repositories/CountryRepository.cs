using Phonebook.V2.Data;
using Phonebook.V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(IPhonebookContext context) : base(context)
        {
        }
    }
}
