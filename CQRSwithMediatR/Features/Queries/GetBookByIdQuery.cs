using CQRSwithMediatR.Context;
using CQRSwithMediatR.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Queries
{
	public class GetBookByIdQuery : IRequest<Book>
	{
		public int Id { get; set; }

		public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
		{
			private readonly IApplicationContext _context;

			public GetBookByIdQueryHandler(IApplicationContext context)
			{
				_context = context;
			}

			public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
			{
				var book = _context.Books.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
				if(book == null)
				{
					return null;
				}
				return book;
			}
		}
	}
}
