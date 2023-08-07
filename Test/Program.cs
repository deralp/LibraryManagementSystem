using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using LibraryManagementSystem.Infrastructure.Token;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using LibraryManagementSystem.Features.Auth;
using LibraryManagementSystem.Features.Book;
using LibraryManagementSystem.Features.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TokenHandler = LibraryManagementSystem.Infrastructure.Token.TokenHandler;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<LibraryContext>(options =>
//    options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<LibraryContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(ITokenHandler), typeof(TokenHandler));
builder.Services.AddHttpContextAccessor();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblyContaining<BookController>();
    x.RegisterServicesFromAssemblyContaining(typeof(UserController));
    x.RegisterServicesFromAssemblyContaining(typeof(AuthController));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware(typeof(ExceptionMiddleware));
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();