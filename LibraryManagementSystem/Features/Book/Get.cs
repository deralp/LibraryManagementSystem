using System.Security.AccessControl;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Features.Book
{
    public class Get
    {
        public class BookDto
        {
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            public bool HasSeries { get; set; }
            public int SeriesNumber { get; set; }
            public int NumberOfCopy { get; set; }
            public int RemainNumberOfCopies { get; set; }
            public List<AuthorDto> Authors { get; set; }
            public List<TypeDto> Types { get; set; }
        }
        public class TypeDto
        {
            public string Name { get; set; }
        }
        public class AuthorDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }
        public class Response
        {
            public List<BookDto> BookDtos { get; set; }
        }
        public class Request : IRequest<Response>
        {
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
                var books = await _context.Books.Where(x => x.DeletedAt == null).Include(x => x.CopyBooks)
                    .Include(x => x.Authors).Include(x => x.Types).ToListAsync(cancellationToken);
                var bookList = new List<BookDto>();
                foreach (var book in books)
                {
                    var bookDto = new BookDto
                    {
                        Name = book.Name,
                        HasSeries = book.HasSeries,
                        NumberOfCopy = book.NumberOfCopy,
                        RemainNumberOfCopies = book.RemainNumberOfCopies,
                        ReleaseDate = book.ReleaseDate,
                        SeriesNumber = book.SeriesNumber,
                    };
                    var authorList = book.Authors.Select(x => new AuthorDto { LastName = x.LastName, FirstName = x.FirstName, BirthDate = x.BirthDate }).ToList();

                    var typeList = book.Types.Select(x => new TypeDto { Name = x.Name, }).ToList();

                    bookDto.Authors = authorList;
                    bookDto.Types = typeList;

                    bookList.Add(bookDto);
                }

                return new Response { BookDtos = bookList };

            }
        }

    }


}
