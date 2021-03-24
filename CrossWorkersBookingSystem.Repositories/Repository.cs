using CrossWorkersBookingSystem.Data;
using CrossWorkersBookingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossWorkersBookingSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookingContext _bookingContext;

        public Repository(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }
        public IQueryable<T> GetAll()
        {
            return _bookingContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _bookingContext.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _bookingContext.Set<T>().Add(entity);
            return entity;
        }
        public void Commit()
        {
            _bookingContext.SaveChangesAsync();
        }


    }
}
