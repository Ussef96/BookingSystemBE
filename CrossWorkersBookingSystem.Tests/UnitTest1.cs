using CrossWorkersBookingSystem.Data;
using CrossWorkersBookingSystem.Models.Models;
using CrossWorkersBookingSystem.Repositories;
using CrossWorkersBookingSystem.Services;
using CrossWorkersBookingSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CrossWorkersBookingSystem.Tests
{
    public class Tests
    {
        private readonly IBookService _bookService;

        public Tests()
        {

            var services = new ServiceCollection();
            services.AddDbContext<BookingContext>(options =>
                options.UseSqlServer("Data Source=.;Initial Catalog=BookingDB;Integrated Security=True"));
            services.AddScoped<IBookService, BookService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            var serviceProvider = services.BuildServiceProvider();
            _bookService = serviceProvider.GetService<IBookService>();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidateBook()
        {
            Booking booking = new Booking { ResourceId = 1, DateFrom = new System.DateTime(2021, 04, 01), DateTo = new System.DateTime(2021, 04, 03), BookedQuantity = 11 };
            var result = _bookService.ValidateBook(booking);
            Assert.IsTrue(result == false);
        }
    }
}
