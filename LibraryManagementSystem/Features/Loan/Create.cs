using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using MediatR;
using System.Security.Claims;

namespace LibraryManagementSystem.Features.Loan;

public class Create
{
    public class Response
    {
        public bool Success { get; set; }
    }

    public class Request : IRequest<Response>
    {
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime EndDate { get; set; }

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
            var userId = user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new NotFoundException("userId not found!");

            var newLoan = new Domain.Loan
            {
                CreatedBy = new Guid(userId),
                CreatedAt = DateTime.UtcNow,
                BookId = request.BookId,
                MemberId = request.MemberId,
                EndDate =request.EndDate,
            };
            await _context.Loans.AddAsync(newLoan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { Success = true };
        }
    }
}