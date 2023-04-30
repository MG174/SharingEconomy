using MediatR;
namespace CQRSwithMediatR.Features.Booking.AddNewBooking
{
    public class AddNewBookingRequest : IRequest<AddNewBookingResponse>
    {
        public int UserId { get; set; }
        public int AdvertismentId { get; set; }
    }
}