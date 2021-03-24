using CrossWorkersBookingSystem.Models.Models;
using CrossWorkersBookingSystem.Repositories;
using CrossWorkersBookingSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossWorkersBookingSystem.Services
{
    public class BookService : IBookService
    {

        private readonly IRepository<Resource> _resourceRepo;
        private readonly IRepository<Booking> _bookingRepo;
        public BookService(IRepository<Resource> resourceRepo, IRepository<Booking> bookingRepo)
        {
            _resourceRepo = resourceRepo;
            _bookingRepo = bookingRepo;
        }

        public IQueryable<Resource> GetAllBooks()
        {

            try
            {
                IQueryable<Resource> books = _resourceRepo.GetAll();
                return books;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public bool ValidateBook(Booking booking)
        {
            try
            {
                var currentBookQuantity = _resourceRepo.GetById(booking.ResourceId).Quantity;
                var matchedResources = _bookingRepo.GetAll().Where(a => a.ResourceId == booking.ResourceId);

                var matchedWithDates = ValidateDate(booking.DateFrom, booking.DateTo, matchedResources);

                int available = (matchedWithDates.Count() == 0) ? matchedResources.Sum(a => a.BookedQuantity) : matchedWithDates.Sum(a => a.BookedQuantity);

                if (currentBookQuantity >= booking.BookedQuantity + available)
                {
                    _bookingRepo.Insert(booking);
                    _bookingRepo.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Booking> ValidateDate(DateTime From, DateTime To, IQueryable<Booking> resources)
        {
            return resources.Where(a => a.DateFrom >= From && a.DateTo <= To);

        }
    }
}
