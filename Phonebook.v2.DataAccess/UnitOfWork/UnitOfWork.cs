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
        private GenericRepository<Country> _countryRepository;
        private GenericRepository<Street> _streetRepository;
        private GenericRepository<Contact> _contactRepository;

        
        public CityRepository CityRepository => _cityRepository ?? (_cityRepository = new CityRepository(_context));

        public GenericRepository<Country> CountryRepository
        {
            get
            {

                if (this._countryRepository == null)
                {
                    this._countryRepository = new GenericRepository<Country>(_context);
                }
                return _countryRepository;
            }
        }

        public GenericRepository<Street> StreetRepository
        {
            get
            {

                if (this._streetRepository == null)
                {
                    this._streetRepository = new GenericRepository<Street>(_context);
                }
                return _streetRepository;
            }
        }

        public GenericRepository<Contact> ContactRepository
        {
            get
            {

                if (this.ContactRepository == null)
                {
                    this._contactRepository = new GenericRepository<Contact>(_context);
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
