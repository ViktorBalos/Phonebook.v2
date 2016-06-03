using Phonebook.V2.Data;
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

        public CountryRepository CountryRepository
        {
            get
            {

                if (this._countryRepository == null)
                {
                    this._countryRepository = new CountryRepository(_context);
                }
                return _countryRepository;
            }
        }

        public StreetRepository StreetRepository
        {
            get
            {

                if (this._streetRepository == null)
                {
                    this._streetRepository = new StreetRepository(_context);
                }
                return _streetRepository;
            }
        }

        public ContactRepository ContactRepository
        {
            get
            {

                if (this._contactRepository == null)
                {
                    this._contactRepository = new ContactRepository(_context);
                }
                return _contactRepository;
            }
        }

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
