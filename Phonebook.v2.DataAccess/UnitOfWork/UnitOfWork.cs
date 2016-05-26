using Phonebook.V2.Data;
using Repositories;
using System;
using System.Data.Entity;

namespace Phonebook.v2.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private IPhonebookContext _context = null;        
        private GenericRepository<City> _CityRepository;
        private GenericRepository<Country> _CountryRepository;
        private GenericRepository<Street> _StreetRepository;
        private GenericRepository<Contact> _ContactRepository;

        //public GenericRepository(IPhonebookContext context)
        //{
        //    _context = context;
        //    _dbGet = _context.Get<T>();
        //}


        public GenericRepository<City> CityRepository
        {
            get
            {

                if (this.CityRepository == null)
                {
                    this._CityRepository = new GenericRepository<City>(_context);
                }
                return CityRepository;
            }
        }

        public GenericRepository<Country> CountryRepository
        {
            get
            {

                if (this.CountryRepository == null)
                {
                    this._CountryRepository = new GenericRepository<Country>(_context);
                }
                return CountryRepository;
            }
        }

        public GenericRepository<Street> StreetRepository
        {
            get
            {

                if (this.StreetRepository == null)
                {
                    this._StreetRepository = new GenericRepository<Street>(_context);
                }
                return StreetRepository;
            }
        }

        public GenericRepository<Contact> ContactRepository
        {
            get
            {

                if (this.ContactRepository == null)
                {
                    this._ContactRepository = new GenericRepository<Contact>(_context);
                }
                return ContactRepository;
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
