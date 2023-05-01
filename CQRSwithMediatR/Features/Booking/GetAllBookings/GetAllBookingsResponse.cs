using System.Collections.Generic;

namespace CQRSwithMediatR.Features.Booking.GetAllBookings
{
    public class GetAllBookingsResponse
    {
        public GetAllBookingsResponse(List<Models.Booking> bookings)
        {
            Bookings = bookings;
        }

        public List<Models.Booking> Bookings { get; set; }
    }
}
