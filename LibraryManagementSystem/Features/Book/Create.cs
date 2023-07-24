using System.Security.AccessControl;
using LibraryManagementSystem.Domain;
using MediatR;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;

namespace LibraryManagementSystem.Features.Book;

public class Create
{
    public class Response
    {
        public bool Success { get; set; }
    }

    public class Request : IRequest<Response>
    {
        public BookDto BookDtos { get; set; }
    }
    public class CopyBookDto
    {
        public string ISBN { get; set; }
        public Guid PublisherId { get; set; }

    }
    public class BookDto
    {
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

            foreach (var authorId in request.BookDtos.AuthorIds)
            {
                var author = await _context.Authors.Where(x => x.Id == authorId).FirstOrDefaultAsync(cancellationToken);
                if (author == null) throw new NotFoundException("Author not found!");
                authorList.Add(author);
            }

            var copyBookList = request.BookDtos.CopyBookDtos.Select(copyBook => new CopyBook { CreatedBy = new Guid(userId!), CreatedAt = DateTime.UtcNow, ISBN = copyBook.ISBN, PublisherId = copyBook.PublisherId }).ToList();

            var bookTypeList = new List<Domain.Type>();
            foreach (var typeId in request.BookDtos.BookTypeIds)
            {
                var bookType = await _context.Types.Where(x=>x.Id == typeId).FirstOrDefaultAsync(cancellationToken);
                if (bookType == null) throw new NotFoundException("BookType not found!");

                bookTypeList.Add(bookType);
            }
            var newBook = new Domain.Book
            {
                CreatedBy = new Guid(userId!),
                Authors = authorList,
                HasSeries = request.BookDtos.HasSeries,
                CreatedAt = DateTime.UtcNow,
                Name = request.BookDtos.Name,
                ReleaseDate = request.BookDtos.ReleaseDate,
                CopyBooks = copyBookList,
                Types = bookTypeList,
                SeriesNumber = request.BookDtos.SeriesNumber,
                NumberOfCopy = copyBookList.Count,
                RemainNumberOfCopies = copyBookList.Count,
            };
            await _context.Books.AddAsync(newBook, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { Success = true };
        }
    }


}