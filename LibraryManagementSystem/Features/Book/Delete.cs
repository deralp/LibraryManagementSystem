using LibraryManagementSystem.Data;
using LibraryManagementSystem.Domain;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Features.Book
{
    public class Delete
    {
        public class Response
        {
            public bool Success { get; set; }
        }

        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
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
                var book = await _context.Books.Where(x => x.Id == request.Id && x.DeletedAt == null).FirstOrDefaultAsync(cancellationToken);
                if (book == null) throw new NotFoundException("Book not found!");

                book.DeletedAt = DateTime.UtcNow;

                var copyBooks = await _context.BookCopies.Where(x => x.BookId == request.Id && x.DeletedAt == null).ToListAsync(cancellationToken);
          
                if (!copyBooks.Any()) throw new ArgumentException("Server Error occured!");

                var copyBookList = new List<CopyBook>();
                foreach (var copyBook in copyBooks)
                {
                    copyBook.DeletedAt = DateTime.UtcNow;
                    copyBookList.Add(copyBook);
                }
                _context.UpdateRange(copyBookList);
                _context.Books.Update(book);
                await _context.SaveChangesAsync(cancellationToken);

                return new Response { Success = true };
            }
        }

    }
}
