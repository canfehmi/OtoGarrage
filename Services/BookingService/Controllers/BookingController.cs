using BookingService.Dtos;
using BookingService.Services.BookingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] CreateBookingDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Booking data is null");
            }
            var booking = await _bookingService.AddBooking(dto);
            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBooking(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
