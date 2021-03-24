using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossWorkersBookingSystem.Models.Models;
using CrossWorkersBookingSystem.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrossWorkersBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BookingController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookingController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet, Route("Books")]
        public IActionResult GetAllBooks()
        {
            IActionResult result;
            try
            {
                result = Ok(_bookService.GetAllBooks());
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.InnerException);

            }
            return result;
        }
        [HttpPost, Route("Reserve")]
        public IActionResult ReserveBook(Booking booking)
        {
            IActionResult result;
            try
            {
                result = Ok(_bookService.ValidateBook(booking));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.InnerException);

            }
            return result;
        }
    }
}
