using CQRSwithMediatR.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Commands
{
	public class DeleteBookCommand : IRequest<int>
	{
		public int Id { get; set; }
		public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
		{
			private readonly IApplicationContext _context;

			public DeleteBookCommandHandler(IApplicationContext context)
			{
				_context = context;
			}

			public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
			{
				var book = await _context.Books.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
				
				if(book == null)
				{
					return default;
				}
				_context.Books.Remove(book);

				int result = await _context.SaveChangesAsync();
				return result;
			}
		}
	}
}
