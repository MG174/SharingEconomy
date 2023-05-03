using System.Collections.Generic;

namespace CQRSwithMediatR.Features.Review.GetReviewsForBooking
{
    public class GetReviewsForBookingResponse
    {
        public GetReviewsForBookingResponse(List<Models.Review> reviews)
        {
            Reviews = reviews;
        }

        public List<Models.Review> Reviews { get; set; }
    }
}
