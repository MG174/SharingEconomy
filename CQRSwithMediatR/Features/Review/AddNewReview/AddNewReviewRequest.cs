using MediatR;
namespace CQRSwithMediatR.Features.Review.AddNewReview
{
    public class AddNewReviewRequest : IRequest<AddNewReviewResponse>
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}