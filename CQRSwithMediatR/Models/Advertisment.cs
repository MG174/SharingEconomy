namespace CQRSwithMediatR.Models
{
	public class Advertisment
	{
		public int AdvertismentId { get; set; }

        public string Title { get; set; }

		public string Description { get; set; }

		public User UserCreatedById { get; set; }

		public string CreatedTime { get; set; }

		public bool Available { get; set; }
	}
}
