using LibraryManagementSystem.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Features.Book;

public class IsAvailable
{
    public class Response
    {
        public bool IsAvailable { get; set; }
    }

    public class Request : IRequest<Response>
    {
        public string Name { get; set; }
    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly LibraryContext _context;

        public Handler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var query = _context.Books.Include(x => x.CopyBooks).ThenInclude(x => x.Publisher).Where(x => x.DeletedAt == null);
            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{request.Name.ToLower()}%"));


            var books = await query.Where(x => x.RemainNumberOfCopies > 0).ToListAsync(cancellationToken);
            return !books.Any() ? new Response { IsAvailable = false } : new Response { IsAvailable = true };
        }
    }
}