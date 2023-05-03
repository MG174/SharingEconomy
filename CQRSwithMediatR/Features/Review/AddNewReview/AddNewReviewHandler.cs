using CQRSwithMediatR.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Features.Review.AddNewReview
{
    public class AddNewReviewHandler : IRequestHandler<AddNewReviewRequest, AddNewReviewResponse>
    {
        private readonly IApplicationContext _context;
        public AddNewReviewHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<AddNewReviewResponse> Handle(AddNewReviewRequest request, CancellationToken cancellationToken)
        {
            var review = new Models.Review();
            var userPerformingBooking = await _context.User.FirstOrDefaultAsync(x => x.UserId == request.UserId);
            var bookingBeingBooked = await _context.Booking.FirstOrDefaultAsync(x => x.BookingId == request.BookingId);
            review.Score = request.Score;
            review.Title = request.Title;
            review.Description = request.Description;
            review.CreatedBy = userPerformingBooking;
            review.BookingRelatedToId = bookingBeingBooked;
            review.CreatedTime = DateTime.Now.ToString();
            _context.Review.Add(review);
            await _context.SaveChangesAsync();
            return new AddNewReviewResponse(review.ReviewId);
        }
    }
}
