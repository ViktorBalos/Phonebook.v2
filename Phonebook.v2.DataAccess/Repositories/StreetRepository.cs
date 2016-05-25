using Phonebook.V2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StreetRepository : GenericRepository<Street>
    {
        public StreetRepository(IPhonebookContext context) : base(context)
        {
        }
    }
}
