using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using LibraryManagementSystem.Infrastructure.Token;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Domain;

namespace LibraryManagementSystem.Features.Auth;

public class Login
{
    public class Response
    {
        public Token AccessToken { get; set; }
    }

    public class Request : IRequest<Response>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly LibraryContext _context;
        private readonly ITokenHandler _token;

        public Handler(LibraryContext context, IConfiguration configuration, ITokenHandler token)
        {
            _context = context;
            _token = token;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var user = _context.Users.Where(x => x.DeletedAt == null && x.UserName == request.UserName && x.Password == request.Password).Include(x => x.Person).ThenInclude(x=>x.Roles).Select(x=>new
            {
                x.Person.FirstName,
                x.Person.Id,
                x.Person.Roles
            }).FirstOrDefault();
            if (user == null) throw new AuthenticationErrorException("UserName or Password incorrect!");

            var claims = new List<Claim>();
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name)); 
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())); 
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));

            Token token = _token.CreateAccessToken(claims);


            return new Response { AccessToken = token };
        }

    }
}

