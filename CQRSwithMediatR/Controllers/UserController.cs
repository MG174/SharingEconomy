using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost(Name = "AddUser")]
		public async Task<IActionResult> AddUser(AddNewUserRequest request)
		{
			return Ok(await _mediator.Send(request));
		}
	}
}
