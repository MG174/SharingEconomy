using CQRSwithMediatR.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Review.GetReviewsForBooking
{
    public class GetReviewsForBookingHandler : IRequestHandler<GetReviewsForBookingRequest, GetReviewsForBookingResponse>
    {
        private readonly IApplicationContext _context;
        public GetReviewsForBookingHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<GetReviewsForBookingResponse> Handle(GetReviewsForBookingRequest request, CancellationToken cancellationToken)
        {
            var reviewBookingHistory = _context.Review.Where(x => x.BookingRelatedToId.BookingId == request.BookingId).ToList();

            return new GetReviewsForBookingResponse(reviewBookingHistory);
        }
    }
}
