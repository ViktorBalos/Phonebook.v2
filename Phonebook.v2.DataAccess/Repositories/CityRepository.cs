using Phonebook.V2.Data;
using Phonebook.V2.DataAccess;
using System.Collections.Generic;
using System.Linq;


namespace Repositories
{
    public class CityRepository : GenericRepository<City>
    {
        public CityRepository(IPhonebookContext context) : base(context)
        {
            
        }

        public List<City> GetCityByCountry(int id)
        {
            var result = (from cities in _context.Cities //koristimo instaciranmi objekat klase PhonebookContex, ta klasa nije staticka!!!!!!!!!!!!!!!!!!!!!!!
                             from countries in _context.Countries
                             where cities.CountryID == countries.ID && countries.ID == id
                             select cities).ToList();

            return result;

        }

        public List<City> GetCityByCountry(string name)//uslov spoja nisi imao
        {
            var result = (
                from grad in _context.Cities //ni DbSet nije staticka klasa
                from drzava in _context.Countries
                where drzava.ID == grad.CountryID && drzava.CountryName == name
                select grad).ToList();

            return result;

        }
    }
}



   


