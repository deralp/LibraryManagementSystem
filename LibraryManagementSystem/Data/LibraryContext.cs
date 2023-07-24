using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using LibraryManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Type = LibraryManagementSystem.Domain.Type;

namespace LibraryManagementSystem.Data;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Domain.Type> Types { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<CopyBook> BookCopies { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Person> Persons { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var alpId = Guid.NewGuid();
        var arinId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var adminId = Guid.NewGuid();
        var ayseId = Guid.NewGuid();
        var memberId = Guid.NewGuid();

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Persons)
            .WithMany(p => p.Roles)
            .UsingEntity(j =>
            {
                j.ToTable("PersonRole"); 
                j.HasData(
                    new { RolesId = adminId, PersonsId = alpId },
                    new { RolesId = userId, PersonsId = arinId }
                );
            });

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = adminId, Name = "Admin", CreatedAt = DateTime.UtcNow },
            new Role { Id = userId, Name = "Librarian", CreatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = alpId, FirstName = "Alp", CreatedAt = DateTime.UtcNow, Address = "Üsküdar/İstanbul", Email = "alpdervis@gmail.com", IdentificationNumberLastFour = 1234, LastName = "Dervis", PhoneNumber = "134242432", CreatedBy = new Guid() },
            new Person { Id = arinId, FirstName = "Arin", CreatedAt = DateTime.UtcNow, Address = "Üsküdar/İstanbul", Email = "arin@gmail.com", IdentificationNumberLastFour = 1664, LastName = "Tekin", PhoneNumber = "23423422", CreatedBy = new Guid() }
        );
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Password = "admin",
                UserName = "admin",
                PersonId = alpId,
                CreatedAt = DateTime.UtcNow
            },
        new User { Id = Guid.NewGuid(), Password = "arin", UserName = "arin123", PersonId = arinId, CreatedAt = DateTime.UtcNow }


        );
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                Name = "Can Yayınları",
                Adress = "İstanbul",
                FoundationDate = DateTime.UtcNow.AddYears(-40),
                Phone = "23434636",
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            });
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                Name = "Yapıkredi Yayınları",
                Adress = "İstanbul",
                FoundationDate = DateTime.UtcNow.AddYears(-30),
                Phone = "23434636",
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            });
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher
            {
                Name = "İş Bankası Yayınları",
                Adress = "İstanbul",
                FoundationDate = DateTime.UtcNow.AddYears(-50),
                Phone = "23434636",
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            });
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                FirstName = "Fyodor",
                LastName = "Dostoevsky",
                CountryOfBirth = "Russia",
                BirthDate = DateTime.UtcNow.AddYears(-202),
                DeathDate = DateTime.UtcNow.AddYears(-142),
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                FirstName = "Friedrich",
                LastName = "Nietzsche",
                CountryOfBirth = "Germany",
                BirthDate = DateTime.UtcNow.AddYears(-179),
                DeathDate = DateTime.UtcNow.AddYears(-123),
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                FirstName = "Franz",
                LastName = "Kafka",
                CountryOfBirth = "Czech Rep",
                BirthDate = DateTime.UtcNow.AddYears(-140),
                DeathDate = DateTime.UtcNow.AddYears(-99),
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                FirstName = "Albert",
                LastName = "Camus",
                CountryOfBirth = "France",
                BirthDate = DateTime.UtcNow.AddYears(-110),
                DeathDate = DateTime.UtcNow.AddYears(-63),
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        modelBuilder.Entity<Type>().HasData(
            new Type
            {
                Name = "Psychological",
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        modelBuilder.Entity<Type>().HasData(
            new Type
            {
                Name = "Biography",
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        modelBuilder.Entity<Type>().HasData(
            new Type
            {
                Name = "Mystery",
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        modelBuilder.Entity<Type>().HasData(
            new Type
            {
                Name = "Fantasy",
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Persons)
            .WithMany(p => p.Roles)
            .UsingEntity(j =>
            {
                j.ToTable("PersonRole"); // Junction table name
                j.HasData(
                    new { RolesId = memberId, PersonsId = ayseId }
                );
            });
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = memberId, Name = "Member", CreatedAt = DateTime.UtcNow }
        );
        modelBuilder.Entity<Person>().HasData(
            new Person
            {

                FirstName = "Ayşe",
                LastName = "Demir",
                CreatedAt = DateTime.UtcNow,
                Address = "İzmir",
                Email = "Ayşe",
                IdentificationNumberLastFour = 1568,
                PhoneNumber = "6542422344",
                Id = ayseId,
            });


        modelBuilder.Entity<Member>().HasData(
                    new Member
                    {
                        PersonId = ayseId,
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.UtcNow,
                        MembershipStartDate = DateTime.UtcNow.AddYears(-1),
                        MembershipEndDate = DateTime.UtcNow.AddYears(1),
                    });


    }
}
