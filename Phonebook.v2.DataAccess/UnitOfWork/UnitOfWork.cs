using Phonebook.V2.Data;
using Phonebook.V2.DataAccess;
using Repositories;
using System;
using System.Data.Entity;

namespace Phonebook.v2.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private IPhonebookContext _context = null;        
        private CityRepository _cityRepository;
        private CountryRepository _countryRepository;
        private StreetRepository _streetRepository;
        private ContactRepository _contactRepository;

        public UnitOfWork(IPhonebookContext context)
        {
            _context = context;
        }
        
        public CityRepository CityRepository => _cityRepository ?? (_cityRepository = new CityRepository(_context));

        public CountryRepository CountryRepository => _countryRepository ?? (_countryRepository = new CountryRepository(_context));

        public StreetRepository StreetRepository => _streetRepository ?? (_streetRepository = new StreetRepository(_context));

        public ContactRepository ContactRepository => _contactRepository ?? (_contactRepository = new ContactRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
