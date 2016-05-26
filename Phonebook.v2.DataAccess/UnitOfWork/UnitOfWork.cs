using Phonebook.V2.Data;
using Repositories;
using System;
using System.Data.Entity;

namespace Phonebook.v2.DataAccess.UnitOfWork
{
    public class UnitOfWork<T> where T:class, IDisposable
    {
        private IPhonebookContext _context = null;        
        private GenericRepository<T> CityRepository;
        private GenericRepository<T> CountryRepository;
        private GenericRepository<T> StreetRepository;

        //public GenericRepository(IPhonebookContext context)
        //{
        //    _context = context;
        //    _dbGet = _context.Get<T>();
        //}


        public GenericRepository<T> _CityRepository
        {
            get
            {

                if (this.CityRepository == null)
                {
                    this.CityRepository = new GenericRepository<T>(_context);
                }
                return CityRepository;
            }
        }

        public GenericRepository<T> _CountryRepository
        {
            get
            {

                if (this.CountryRepository == null)
                {
                    this.CountryRepository = new GenericRepository<T>(_context);
                }
                return CountryRepository;
            }
        }

        public GenericRepository<T> _StreetRepository
        {
            get
            {

                if (this.StreetRepository == null)
                {
                    this.StreetRepository = new GenericRepository<T>(_context);
                }
                return StreetRepository;
            }
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
