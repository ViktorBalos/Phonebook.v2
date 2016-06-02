using Phonebook.V2.Data;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<City> GetCityByCountry(int id)
        {
            var mozdaovako = (
            from grad in PhonebookContext
            from drzava in PhonebookContext
            where City.CountryID == Country.ID )
            .ToList();
            return mozdaovako;

        }

        public List<City> GetCityByCountry(string name)
        {
            var mozdaovako = (
                from grad in DbSet < City >
                from drzava in DbSet < Country >
                where Country.CountryName == name
                select City.CityName)
                .ToList();
            return mozdaovako;

        }
    }
}



   


