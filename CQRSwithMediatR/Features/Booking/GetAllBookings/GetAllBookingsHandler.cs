using CQRSwithMediatR.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Booking.GetAllBookings
{
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookingsRequest, GetAllBookingsResponse>
    {
        private readonly IApplicationContext _context;
        public GetAllBookingsHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetAllBookingsResponse> Handle(GetAllBookingsRequest request, CancellationToken cancellationToken)
        {
            var userBookingHistory = _context.Booking.Where(x => x.UserBookedById.UserId == request.UserId).ToList();

            return new GetAllBookingsResponse(userBookingHistory);
        }
    }
}
