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

        public List<Street> GetStreetByCity(int id)
        {
            var result = (from streets in _context.Streets 
                          from cities in _context.Cities
                          where streets.CityID == cities.ID && cities.ID == id
                          select streets).ToList();

            return result;

        }

        public List<Street> GetStreetByCity(string name)
        {
            var result = (
                from ulica in _context.Streets
                from grad in _context.Cities
                where ulica.ID == ulica.CityID && grad.CityName == name
                select ulica).ToList();

            return result;

        }
    }
}
