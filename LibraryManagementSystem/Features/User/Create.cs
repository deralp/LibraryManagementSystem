using System.Security.AccessControl;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Domain;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using MediatR;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Features.User;

public class Create
{
    public class Response
    {
        public bool Success { get; set; }
    }

    public class Request : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int IdentificationNumberLastFour { get; set; }
        public List<Guid> RoleIds { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }


    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly LibraryContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(LibraryContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new NotFoundException("userId not found!");
            var roleList = new List<Role>();

            foreach (var roleId in request.RoleIds)
            {
                var role = await _context.Roles.Where(x => x.Id == roleId).FirstOrDefaultAsync(cancellationToken);
                if (role == null) throw new NotFoundException($"Role not found! RoleId:{roleId}");
                roleList.Add(role);
            }


            var newPerson = new Person
            {
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = new Guid(userId),
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                IdentificationNumberLastFour = request.IdentificationNumberLastFour,
                Roles = roleList,
                
            };
            var newUser = new Domain.User
            {
                CreatedAt = DateTime.UtcNow,
                CreatedBy = new Guid(userId),
                Password = request.Password,
                UserName = request.UserName,
                Person = newPerson,

            };


            await _context.Users.AddAsync(newUser, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response { Success = true };
        }
    }
}