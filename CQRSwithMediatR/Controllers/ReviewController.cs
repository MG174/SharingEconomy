using CQRSwithMediatR.Features.Review.AddNewReview;
using CQRSwithMediatR.Features.Review.GetReviewsForBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : Controller
	{
		private readonly IMediator _mediator;

		public ReviewController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("AddReview")]
		public async Task<IActionResult> AddReview(AddNewReviewRequest request)
		{
			return Ok(await _mediator.Send(request));
		}

		[HttpPost("GetSpecificReview")]
		public async Task<IActionResult> GetSpecificReview(GetReviewsForBookingRequest request)
		{
			return Ok(await _mediator.Send(request));
		}
	}
}
