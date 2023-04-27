using CQRSwithMediatR.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.User.AddNewUser
{
	public class AddNewUserHandler : IRequestHandler<AddNewUserRequest, AddNewUserResponse>
	{
		private readonly IApplicationContext _context;

		public AddNewUserHandler(IApplicationContext context)
		{
			_context = context;
		}
		public async Task<AddNewUserResponse> Handle(AddNewUserRequest request, CancellationToken cancellationToken)
		{
			var user = new Models.User();
			user.Name = request.Name;
			user.Surname = request.Surname;
			user.AccountType = request.AccountType;
			_context.User.Add(user);

			await _context.SaveChangesAsync();

			return new AddNewUserResponse();
		}
	}
}
