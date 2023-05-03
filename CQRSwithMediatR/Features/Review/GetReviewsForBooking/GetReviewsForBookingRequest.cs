using MediatR;

namespace CQRSwithMediatR.Features.Review.GetReviewsForBooking
{
    public class GetReviewsForBookingRequest : IRequest<GetReviewsForBookingResponse>
    {
        public int BookingId { get; set; }
    }
}