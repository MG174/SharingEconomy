using CQRSwithMediatR.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CQRSwithMediatR.Features.Booking.AddNewBooking
{
    public class AddNewBookingHandler : IRequestHandler<AddNewBookingRequest, AddNewBookingResponse>
    {
        private readonly IApplicationContext _context;
        public AddNewBookingHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<AddNewBookingResponse> Handle(AddNewBookingRequest request, CancellationToken cancellationToken)
        {
            _context.BeginTransaction();
            var booking = new Models.Booking();
            var userPerformingBooking = await _context.User.FirstOrDefaultAsync(x => x.UserId == request.UserId);
            var advertismentBeingBooked = await _context.Advertisment.FirstOrDefaultAsync(x => x.AdvertismentId == request.AdvertismentId);
            if (advertismentBeingBooked.Available)
            {
                booking.UserBookedById = userPerformingBooking;
                booking.AdvertismentBookedId = advertismentBeingBooked;
                booking.BookedTime = DateTime.Now.ToString();
                advertismentBeingBooked.Available = false;
                _context.Booking.Add(booking);
                _context.Advertisment.Update(advertismentBeingBooked);
                await _context.SaveChangesAsync();
                _context.CommitTransaction();
                return new AddNewBookingResponse(booking.BookingId); 
            }
            else
            {
                return new AddNewBookingResponse();
            }
        }
    }
}
