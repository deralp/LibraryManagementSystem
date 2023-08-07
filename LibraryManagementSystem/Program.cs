using System.Reflection;
using System.Text;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.ExceptionHandler;
using LibraryManagementSystem.Infrastructure.Token;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TokenHandler = LibraryManagementSystem.Infrastructure.Token.TokenHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<LibraryContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton(typeof(ITokenHandler), typeof(TokenHandler));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
            },
            Array.Empty<string>()
        }
    });
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryManagementSystem", Version = "v1" });
});
builder.Services.AddControllersWithViews();
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
    option.AddPolicy("Admin",policy => policy.RequireRole("Admin"));
});

builder.Services.ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds(s => s.FullName?.Replace("+", "."));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(ExceptionMiddleware));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
