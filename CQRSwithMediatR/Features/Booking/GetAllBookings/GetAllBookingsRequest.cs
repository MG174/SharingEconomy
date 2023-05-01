using MediatR;

namespace CQRSwithMediatR.Features.Booking.GetAllBookings
{
    public class GetAllBookingsRequest : IRequest<GetAllBookingsResponse>
    {
        public int UserId { get; set; }
    }
}