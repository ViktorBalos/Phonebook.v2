using Phonebook.V2.Data;
using Phonebook.V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ContactRepository : GenericRepository<Contact>
    {
        public ContactRepository(IPhonebookContext context) : base(context)
        {
        }
    }
}
