namespace CQRSwithMediatR.Models
{
	public class Review
	{
		public int ReviewId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int Score { get; set; }

		public User CreatedBy { get; set; }

		public Booking BookingRelatedToId { get; set; }

		public string CreatedTime { get; set; }
	}
}
