using MediatR;
using CQRSwithMediatR.Features.User.AddNewUser;

public class AddNewUserRequest : IRequest<AddNewUserResponse>
{
	public int UserId { get; set; }

	public string Name { get; set; }

	public string Surname { get; set; }

	public string AccountType { get; set; }
}