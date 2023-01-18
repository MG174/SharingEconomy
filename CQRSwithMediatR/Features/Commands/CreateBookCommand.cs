using CQRSwithMediatR.Context;
using CQRSwithMediatR.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Commands
{
	public class CreateBookCommand : IRequest<int>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }

		public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
		{
			private readonly IApplicationContext _context;

			public CreateBookCommandHandler(IApplicationContext context)
			{
				_context = context;
			}
			public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
			{
				var book = new Book();
				book.Author = request.Author;
				book.Description = request.Description;
				book.Name = request.Name;
				_context.Books.Add(book);

				int result = await _context.SaveChangesAsync();

				return result;
			}
		}
	}
}
