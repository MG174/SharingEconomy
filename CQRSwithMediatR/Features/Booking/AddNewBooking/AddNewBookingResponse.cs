namespace CQRSwithMediatR.Features.Booking.AddNewBooking
{
    public class AddNewBookingResponse
    {
        public AddNewBookingResponse(int bookingId)
        {
            BookingId = bookingId;
        }

        public AddNewBookingResponse()
        {
        }

        public int? BookingId { get; set; }
    }
}
