namespace CQRSwithMediatR.Models
{
	public class Advertisment
	{
		public int AdvertismentId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string CreatedTime { get; set; }

		public User CreatedBy { get; set; }

		public bool Available { get; set; }

		public string CurrentLocation { get; set; }
	}
}
