using CrossWorkersBookingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossWorkersBookingSystem.Services.Interface
{
    public interface IBookService
    {
        public IQueryable<Resource> GetAllBooks();

        public bool ValidateBook(Booking booking);

        public IQueryable<Booking> ValidateDate(DateTime From, DateTime To, IQueryable<Booking> resources);

    }
}
