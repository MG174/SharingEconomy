using CQRSwithMediatR.Features.Booking.AddNewBooking;
using CQRSwithMediatR.Features.Booking.GetAllBookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : Controller
	{
		private readonly IMediator _mediator;

		public BookingController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("AddBooking")]
		public async Task<IActionResult> AddBooking(AddNewBookingRequest request)
		{
			return Ok(await _mediator.Send(request));
		}

		[HttpPost("GetAllBookingsRequest")]
		public async Task<IActionResult> GetAllBookings(GetAllBookingsRequest request)
		{
			return Ok(await _mediator.Send(request));
		}
	}
}
