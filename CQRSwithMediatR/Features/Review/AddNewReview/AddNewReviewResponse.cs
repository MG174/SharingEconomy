namespace CQRSwithMediatR.Features.Review.AddNewReview
{
    public class AddNewReviewResponse
    {
        public AddNewReviewResponse(int reviewId)
        {
            ReviewId = reviewId;
        }

        public AddNewReviewResponse()
        {
        }

        public int? ReviewId { get; set; }
    }
}
