using CQRSwithMediatR.Context;
using CQRSwithMediatR.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Queries
{
	public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
	{
		public class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
		{
			private readonly IApplicationContext _context;

			public GetAllBooksQueryHandler(IApplicationContext context)
			{
				_context = context;
			}

			public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancelationToken)
			{
				var bookList = await _context.Books.ToListAsync();
				if(bookList == null)
				{
					return null;
				}
				return bookList;
			}
		}
	}
}
