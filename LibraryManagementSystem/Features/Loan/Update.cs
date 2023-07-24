using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using MediatR;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Features.Loan;

public class Update
{
    public class Response
    {
        public bool Success { get; set; }
        public string PenaltyFee { get; set; }
    }

    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LibraryContext _context;

        public Handler(IHttpContextAccessor httpContextAccessor, LibraryContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirstValue(ClaimTypes.NameIdentifier) ??
                         throw new NotFoundException("userId not found!");
            var loan = await _context.Loans.Where(x => x.ReturnDate == null && x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            loan.ReturnDate = DateTime.UtcNow;
            loan.UpdatedBy = new Guid(userId);
            loan.UpdatedAt = DateTime.UtcNow;


            var day = DateTime.UtcNow.Date - loan.EndDate.Date;
            loan.PenaltyPayment = day.Days < 30 ? 0 : 10;

            _context.Loans.Update(loan);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { PenaltyFee = $"{loan.PenaltyPayment} tl", Success = true };
        }
    }
}