
using CrossWorkersBookingSystem.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CrossWorkersBookingSystem.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Name = "Anna Karenina", Quantity = 10, Id = 1 });
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Name = "To Kill a Mockingbird", Quantity = 5, Id = 2 });
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Name = "The Great Gatsby", Quantity = 4, Id = 3 });

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, BookedQuantity = 2, ResourceId = 3, DateFrom = new System.DateTime(2021, 04, 08), DateTo = new System.DateTime(2021, 04, 10) });
        }

        public DbSet<Resource> Resource { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
