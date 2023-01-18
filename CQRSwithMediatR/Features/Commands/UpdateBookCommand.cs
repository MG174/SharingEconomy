using CQRSwithMediatR.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Commands
{
	public class UpdateBookCommand : IRequest<int>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }

		public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
		{
			private readonly IApplicationContext _context;
			public UpdateBookCommandHandler(IApplicationContext context)
			{
				_context = context;
			}
			public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
			{
				var book = _context.Books.Where(a => a.Id == request.Id).FirstOrDefault();
				if (book == null)
				{
					return default;
				}
				else
				{
					book.Author = request.Author;
					book.Description = request.Description;
					book.Name = request.Name;

					int result = await _context.SaveChangesAsync();
					return result;
				}
			}
		}
	}
}
