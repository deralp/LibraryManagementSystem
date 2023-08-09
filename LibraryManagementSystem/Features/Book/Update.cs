using LibraryManagementSystem.Data;
using LibraryManagementSystem.Domain;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryManagementSystem.Features
{
    public class Update
    {
        public class Response
        {
            public bool Success { get; set; }
        }
        public class Request : IRequest<Response>
        {
            public BookDto BookDto { get; set; }
        }
        public class CopyBookDto
        {
            public string ISBN { get; set; }
            public Guid PublisherId { get; set; }

        }
        public class BookDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            public bool HasSeries { get; set; }
            public int SeriesNumber { get; set; }
            public List<Guid> BookTypeIds { get; set; }
            public List<Guid> AuthorIds { get; set; }
            public List<CopyBookDto> CopyBookDtos { get; set; }
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

                var authorList = new List<Author>();

                var book = await _context.Books.Where(x => x.DeletedAt == null && x.Id == request.BookDto.Id).Include(x=>x.Authors).Include(x=>x.Types).FirstOrDefaultAsync(cancellationToken);

                foreach (var authorId in request.BookDto.AuthorIds)
                {
                    var author = await _context.Authors.Where(x => x.Id == authorId).FirstOrDefaultAsync(cancellationToken);
                    if (author == null) throw new NotFoundException("Author not found!");
                    authorList.Add(author);
                }

                var copyBookList = request.BookDto.CopyBookDtos.Select(copyBook => new CopyBook { CreatedBy = new Guid(userId!), CreatedAt = DateTime.UtcNow, ISBN = copyBook.ISBN, PublisherId = copyBook.PublisherId }).ToList();

                var bookTypeList = new List<Domain.Type>();
                foreach (var typeId in request.BookDto.BookTypeIds)
                {
                    var bookType = await _context.Types.Where(x => x.Id == typeId).FirstOrDefaultAsync(cancellationToken);
                    if (bookType == null) throw new NotFoundException("BookType not found!");

                    bookTypeList.Add(bookType);
                }




                book.Authors = authorList;
                book.HasSeries = request.BookDto.HasSeries;
                book.Name = request.BookDto.Name;
                book.ReleaseDate = request.BookDto.ReleaseDate;
                book.CopyBooks = copyBookList;
                book.Types = bookTypeList;
                book.SeriesNumber = request.BookDto.SeriesNumber;
                book.NumberOfCopy = copyBookList.Count;
                book.RemainNumberOfCopies = copyBookList.Count;
                book.UpdatedAt = DateTime.UtcNow;
                book.UpdatedBy = new Guid(userId);
                

                _context.Books.Update(book);
                await _context.SaveChangesAsync(cancellationToken);

                return new Response { Success = true };

            }
        }
    }
}
