namespace CQRSwithMediatR.Models
{
	public class Booking
	{
		public int BookingId { get; set; }

		public Advertisment AdvertismentBookedId { get; set; }

		public User UserBookedById { get; set; }

		public string BookedTime { get; set; }

	}
}
