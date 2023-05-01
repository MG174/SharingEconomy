namespace CQRSwithMediatR.Models
{
	public class Booking
	{
		public int BookingId { get; set; }

		public Advertisment AdvertismentBookedId { get; set; } = new Advertisment();

		public User UserBookedById { get; set; } = new User();

		public string BookedTime { get; set; }
	}
}
