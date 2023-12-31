﻿// <auto-generated />
using System;
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20230724135805_Done_Migration")]
    partial class Done_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookType", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypesId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("BookType");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CountryOfBirth")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6b8f994-9724-478a-b1dc-d093a0e22e7f"),
                            BirthDate = new DateTime(1821, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5981),
                            CountryOfBirth = "Russia",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5986),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeathDate = new DateTime(1881, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5985),
                            FirstName = "Fyodor",
                            LastName = "Dostoevsky"
                        },
                        new
                        {
                            Id = new Guid("73302431-1690-408d-8c41-0bff8b64269f"),
                            BirthDate = new DateTime(1844, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5995),
                            CountryOfBirth = "Germany",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5999),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeathDate = new DateTime(1900, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5997),
                            FirstName = "Friedrich",
                            LastName = "Nietzsche"
                        },
                        new
                        {
                            Id = new Guid("ce31335f-07bd-4a84-8cb4-901f56de6cd6"),
                            BirthDate = new DateTime(1883, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6006),
                            CountryOfBirth = "Czech Rep",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6008),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeathDate = new DateTime(1924, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6007),
                            FirstName = "Franz",
                            LastName = "Kafka"
                        },
                        new
                        {
                            Id = new Guid("10a5a0b7-ba46-46e7-a172-3d62f5f45dea"),
                            BirthDate = new DateTime(1913, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6015),
                            CountryOfBirth = "France",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6017),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeathDate = new DateTime(1960, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6016),
                            FirstName = "Albert",
                            LastName = "Camus"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("HasSeries")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfCopy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RemainNumberOfCopies")
                        .HasColumnType("integer");

                    b.Property<int>("SeriesNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.CopyBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid");

                    b.Property<int>("PenaltyPayment")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("MembershipEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("MembershipStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = new Guid("38e1e685-ab86-45a1-a78a-cd528dd1bfe6"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6330),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            MembershipEndDate = new DateTime(2024, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6332),
                            MembershipStartDate = new DateTime(2022, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6331),
                            PersonId = new Guid("202cacbe-c3a6-46c5-8b2b-b269a55cbccc")
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdentificationNumberLastFour")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2d1d697-3cf8-49e6-8e83-9d571bf48f92"),
                            Address = "Üsküdar/İstanbul",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5886),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Email = "alpdervis@gmail.com",
                            FirstName = "Alp",
                            IdentificationNumberLastFour = 1234,
                            LastName = "Dervis",
                            PhoneNumber = "134242432"
                        },
                        new
                        {
                            Id = new Guid("efa75bdc-0f54-4cc3-9080-6fd4c7fabc6a"),
                            Address = "Üsküdar/İstanbul",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5889),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Email = "arin@gmail.com",
                            FirstName = "Arin",
                            IdentificationNumberLastFour = 1664,
                            LastName = "Tekin",
                            PhoneNumber = "23423422"
                        },
                        new
                        {
                            Id = new Guid("202cacbe-c3a6-46c5-8b2b-b269a55cbccc"),
                            Address = "İzmir",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6311),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Email = "Ayşe",
                            FirstName = "Ayşe",
                            IdentificationNumberLastFour = 1568,
                            LastName = "Demir",
                            PhoneNumber = "6542422344"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58fd4e76-6882-4b0e-82d1-c560e5da838a"),
                            Adress = "İstanbul",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5944),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            FoundationDate = new DateTime(1983, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5937),
                            Name = "Can Yayınları",
                            Phone = "23434636"
                        },
                        new
                        {
                            Id = new Guid("5de8f18e-0b5c-4226-b168-a54cd46c1c00"),
                            Adress = "İstanbul",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5955),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            FoundationDate = new DateTime(1993, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5953),
                            Name = "Yapıkredi Yayınları",
                            Phone = "23434636"
                        },
                        new
                        {
                            Id = new Guid("5c96ab31-7b16-445c-bc4c-2cb3d722efdf"),
                            Adress = "İstanbul",
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5964),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            FoundationDate = new DateTime(1973, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5962),
                            Name = "İş Bankası Yayınları",
                            Phone = "23434636"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1ac6ea8d-180e-4d37-9789-2c5e68e0bfb1"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5868),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("4beaca3a-974e-4cea-aa63-b4d6b504e2d1"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5871),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Librarian"
                        },
                        new
                        {
                            Id = new Guid("0eda9c2a-584d-42d0-96c9-6c574286cf54"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6302),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Member"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c350d8c3-bfb4-4165-a88a-4aec32c739f5"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6031),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Psychological"
                        },
                        new
                        {
                            Id = new Guid("6dc7c814-9481-4f87-8472-32b855c6bce0"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6041),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Biography"
                        },
                        new
                        {
                            Id = new Guid("9f61e512-53ba-4b73-895f-fefeac67ed4f"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6049),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = new Guid("98092aee-0f77-4412-91de-f566aebcfed1"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(6057),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("189264b9-75b0-43c3-b49b-4ae429a32e96"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5912),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Password = "admin",
                            PersonId = new Guid("c2d1d697-3cf8-49e6-8e83-9d571bf48f92"),
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("81305680-5027-4e72-ae15-a241da1c0900"),
                            CreatedAt = new DateTime(2023, 7, 24, 13, 58, 5, 234, DateTimeKind.Utc).AddTicks(5922),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Password = "arin",
                            PersonId = new Guid("efa75bdc-0f54-4cc3-9080-6fd4c7fabc6a"),
                            UserName = "arin123"
                        });
                });

            modelBuilder.Entity("PersonRole", b =>
                {
                    b.Property<Guid>("PersonsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.HasKey("PersonsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("PersonRole", (string)null);

                    b.HasData(
                        new
                        {
                            PersonsId = new Guid("c2d1d697-3cf8-49e6-8e83-9d571bf48f92"),
                            RolesId = new Guid("1ac6ea8d-180e-4d37-9789-2c5e68e0bfb1")
                        },
                        new
                        {
                            PersonsId = new Guid("efa75bdc-0f54-4cc3-9080-6fd4c7fabc6a"),
                            RolesId = new Guid("4beaca3a-974e-4cea-aa63-b4d6b504e2d1")
                        },
                        new
                        {
                            PersonsId = new Guid("202cacbe-c3a6-46c5-8b2b-b269a55cbccc"),
                            RolesId = new Guid("0eda9c2a-584d-42d0-96c9-6c574286cf54")
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Domain.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookType", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Domain.Type", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.CopyBook", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Book", "Book")
                        .WithMany("CopyBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Domain.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Loan", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Domain.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Member", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.User", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PersonRole", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Book", b =>
                {
                    b.Navigation("CopyBooks");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Member", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
