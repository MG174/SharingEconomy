using CQRSwithMediatR.Features.Commands;
using CQRSwithMediatR.Features.Queries;
using CQRSwithMediatR.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : Controller
	{
		private readonly IMediator _mediator;

		public BookController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/<BookController>
		[HttpGet]
		public async Task<ActionResult<Book>> GetAllBooks()
		{
			return Ok(await _mediator.Send(new GetAllBooksQuery()));
		}

		// GET:api/<BookController>/1
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _mediator.Send(new GetBookByIdQuery() { Id = id }));
        }

		// POST: api/<BookController>/1
		[HttpPost(Name = "UpdateBook")]
		public async Task<IActionResult> UpdateBook(CreateBookCommand command)
		{
			return Ok(await _mediator.Send(command));
		}

		// PUT: api/<BookController>/1
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBookByUd(int id, UpdateBookCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}
			return Ok(await _mediator.Send(command));
		}

		// DELETE: api/<BookController>/1
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await _mediator.Send(new DeleteBookCommand { Id = id }));
		}
	}
}
