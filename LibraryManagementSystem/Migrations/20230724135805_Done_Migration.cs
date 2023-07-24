using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Done_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CountryOfBirth = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HasSeries = table.Column<bool>(type: "boolean", nullable: false),
                    SeriesNumber = table.Column<int>(type: "integer", nullable: false),
                    NumberOfCopy = table.Column<int>(type: "integer", nullable: false),
                    RemainNumberOfCopies = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IdentificationNumberLastFour = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    MembershipStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MembershipEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: false),
                    ISBN = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCopies_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    PersonsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => new { x.PersonsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_PersonRole_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => new { x.BooksId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_BookType_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookType_Types_TypesId",
                        column: x => x.TypesId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PenaltyPayment = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "CountryOfBirth", "CreatedAt", "CreatedBy", "DeathDate", "DeletedAt", "DeletedBy", "FirstName", "LastName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("10a5a0b7-ba46-46e7-a172-3d62f5f45dea"), new DateTime(1913, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6015), "France", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6017), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1960, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6016), null, null, "Albert", "Camus", null, null },
                    { new Guid("73302431-1690-408d-8c41-0bff8b64269f"), new DateTime(1844, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5995), "Germany", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5999), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1900, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5997), null, null, "Friedrich", "Nietzsche", null, null },
                    { new Guid("a6b8f994-9724-478a-b1dc-d093a0e22e7f"), new DateTime(1821, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5981), "Russia", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5986), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1881, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5985), null, null, "Fyodor", "Dostoevsky", null, null },
                    { new Guid("ce31335f-07bd-4a84-8cb4-901f56de6cd6"), new DateTime(1883, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6006), "Czech Rep", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6008), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1924, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6007), null, null, "Franz", "Kafka", null, null }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "IdentificationNumberLastFour", "LastName", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("202cacbe-c3a6-46c5-8b2b-b269a55cbccc"), "İzmir", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6311), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Ayşe", "Ayşe", 1568, "Demir", "6542422344", null, null },
                    { new Guid("c2d1d697-3cf8-49e6-8e83-9d571bf48f92"), "Üsküdar/İstanbul", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5886), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "alpdervis@gmail.com", "Alp", 1234, "Dervis", "134242432", null, null },
                    { new Guid("efa75bdc-0f54-4cc3-9080-6fd4c7fabc6a"), "Üsküdar/İstanbul", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5889), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "arin@gmail.com", "Arin", 1664, "Tekin", "23423422", null, null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Adress", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FoundationDate", "Name", "Phone", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("58fd4e76-6882-4b0e-82d1-c560e5da838a"), "İstanbul", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5944), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new DateTime(1983, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5937), "Can Yayınları", "23434636", null, null },
                    { new Guid("5c96ab31-7b16-445c-bc4c-2cb3d722efdf"), "İstanbul", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5964), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new DateTime(1973, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5962), "İş Bankası Yayınları", "23434636", null, null },
                    { new Guid("5de8f18e-0b5c-4226-b168-a54cd46c1c00"), "İstanbul", new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5955), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new DateTime(1993, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5953), "Yapıkredi Yayınları", "23434636", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0eda9c2a-584d-42d0-96c9-6c574286cf54"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6302), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Member", null, null },
                    { new Guid("1ac6ea8d-180e-4d37-9789-2c5e68e0bfb1"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5868), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Admin", null, null },
                    { new Guid("4beaca3a-974e-4cea-aa63-b4d6b504e2d1"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5871), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Librarian", null, null }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("6dc7c814-9481-4f87-8472-32b855c6bce0"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6041), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Biography", null, null },
                    { new Guid("98092aee-0f77-4412-91de-f566aebcfed1"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6057), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Fantasy", null, null },
                    { new Guid("9f61e512-53ba-4b73-895f-fefeac67ed4f"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6049), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Mystery", null, null },
                    { new Guid("c350d8c3-bfb4-4165-a88a-4aec32c739f5"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6031), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "Psychological", null, null }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "MembershipEndDate", "MembershipStartDate", "PersonId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("38e1e685-ab86-45a1-a78a-cd528dd1bfe6"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6330), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new DateTime(2024, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6332), new DateTime(2022, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6331), new Guid("202cacbe-c3a6-46c5-8b2b-b269a55cbccc"), null, null });

            migrationBuilder.InsertData(
                table: "PersonRole",
                columns: new[] { "PersonsId", "RolesId" },
                values: new object[,]
                {
                    { new Guid("202cacbe-c3a6-46c5-8b2b-b269a55cbccc"), new Guid("0eda9c2a-584d-42d0-96c9-6c574286cf54") },
                    { new Guid("c2d1d697-3cf8-49e6-8e83-9d571bf48f92"), new Guid("1ac6ea8d-180e-4d37-9789-2c5e68e0bfb1") },
                    { new Guid("efa75bdc-0f54-4cc3-9080-6fd4c7fabc6a"), new Guid("4beaca3a-974e-4cea-aa63-b4d6b504e2d1") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Password", "PersonId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { new Guid("189264b9-75b0-43c3-b49b-4ae429a32e96"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5912), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "admin", new Guid("c2d1d697-3cf8-49e6-8e83-9d571bf48f92"), null, null, "admin" },
                    { new Guid("81305680-5027-4e72-ae15-a241da1c0900"), new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5922), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "arin", new Guid("efa75bdc-0f54-4cc3-9080-6fd4c7fabc6a"), null, null, "arin123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookId",
                table: "BookCopies",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_PublisherId",
                table: "BookCopies",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookType_TypesId",
                table: "BookType",
                column: "TypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberId",
                table: "Loans",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PersonId",
                table: "Members",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_RolesId",
                table: "PersonRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
