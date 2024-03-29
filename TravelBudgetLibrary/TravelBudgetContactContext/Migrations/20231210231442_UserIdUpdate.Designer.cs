﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBudgetDBContact;

#nullable disable

namespace TravelBudgetDBContact.Migrations
{
    [DbContext(typeof(DBContact))]
    [Migration("20231210231442_UserIdUpdate")]
    partial class UserIdUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CountryTravel", b =>
                {
                    b.Property<int>("CountriesId")
                        .HasColumnType("int");

                    b.Property<int>("TravelsId")
                        .HasColumnType("int");

                    b.HasKey("CountriesId", "TravelsId");

                    b.HasIndex("TravelsId");

                    b.ToTable("CountryTravel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Accommodation"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Food"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Transport"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Attractions"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Shopping"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Others"
                        });
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "At the first day..."
                        },
                        new
                        {
                            Id = 2,
                            Content = "At the first day..."
                        },
                        new
                        {
                            Id = 3,
                            Content = "At the first day..."
                        });
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Continents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Europe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Africa"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Asia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "North America"
                        },
                        new
                        {
                            Id = 5,
                            Name = "South America"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Australia"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Zelandia"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Antarctica"
                        });
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContinentId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PL",
                            ContinentId = 1,
                            CurrencyId = 1,
                            Name = "Poland"
                        },
                        new
                        {
                            Id = 2,
                            Code = "SE",
                            ContinentId = 2,
                            CurrencyId = 5,
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 3,
                            Code = "BR",
                            ContinentId = 5,
                            CurrencyId = 3,
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = 4,
                            Code = "CR",
                            ContinentId = 5,
                            CurrencyId = 3,
                            Name = "Costa Rica"
                        },
                        new
                        {
                            Id = 5,
                            Code = "JP",
                            ContinentId = 3,
                            CurrencyId = 6,
                            Name = "Japan"
                        });
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PLN"
                        },
                        new
                        {
                            Id = 2,
                            Code = "EUR"
                        },
                        new
                        {
                            Id = 3,
                            Code = "USD"
                        },
                        new
                        {
                            Id = 4,
                            Code = "GBP"
                        },
                        new
                        {
                            Id = 5,
                            Code = "SEK"
                        },
                        new
                        {
                            Id = 6,
                            Code = "JPY"
                        });
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("TravelId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CountryId = 2,
                            Date = new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            Description = "I bought a souvenir",
                            Price = 25.5,
                            TravelId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CountryId = 1,
                            Date = new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            Description = "Random text1",
                            Price = 88.0,
                            TravelId = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CountryId = 1,
                            Date = new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            Description = "Random text2",
                            Price = 102.3,
                            TravelId = 2
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            CountryId = 1,
                            Date = new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            Description = "Random text3",
                            Price = 34.5,
                            TravelId = 2
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CountryId = 4,
                            Date = new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            Description = "Random text4",
                            Price = 130.0,
                            TravelId = 3
                        });
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Travel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId")
                        .IsUnique()
                        .HasFilter("[CommentId] IS NOT NULL");

                    b.ToTable("Travels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            CommentId = 1,
                            Description = "Visiting castles around Poland",
                            FinishDate = new DateTime(2022, 12, 16, 21, 15, 0, 0, DateTimeKind.Unspecified),
                            Name = "Around Poland",
                            StartingDate = new DateTime(2022, 12, 12, 6, 15, 0, 0, DateTimeKind.Unspecified),
                            UserId = "c9c98838-1475-49b6-a54d-6aa6cd4e5bdc"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CommentId = 2,
                            Description = "Visiting forests",
                            FinishDate = new DateTime(2023, 10, 12, 21, 15, 0, 0, DateTimeKind.Unspecified),
                            Name = "Around Poland",
                            StartingDate = new DateTime(2023, 9, 18, 6, 15, 0, 0, DateTimeKind.Unspecified),
                            UserId = "c9c98838-1475-49b6-a54d-6aa6cd4e5bdc"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CommentId = 3,
                            Description = "Mazurian lakes",
                            FinishDate = new DateTime(2023, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified),
                            Name = "Around Poland",
                            StartingDate = new DateTime(2023, 6, 18, 6, 15, 0, 0, DateTimeKind.Unspecified),
                            UserId = "c9c98838-1475-49b6-a54d-6aa6cd4e5bdc"
                        });
                });

            modelBuilder.Entity("CountryTravel", b =>
                {
                    b.HasOne("TravelBudgetDBModels.Models.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetDBModels.Models.Travel", null)
                        .WithMany()
                        .HasForeignKey("TravelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Country", b =>
                {
                    b.HasOne("TravelBudgetDBModels.Models.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetDBModels.Models.Currency", "Currency")
                        .WithMany("Countries")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Expense", b =>
                {
                    b.HasOne("TravelBudgetDBModels.Models.Category", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetDBModels.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetDBModels.Models.Travel", "Travel")
                        .WithMany("Expenses")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Travel", b =>
                {
                    b.HasOne("TravelBudgetDBModels.Models.Comment", "Comment")
                        .WithOne("Travel")
                        .HasForeignKey("TravelBudgetDBModels.Models.Travel", "CommentId");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Category", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Comment", b =>
                {
                    b.Navigation("Travel")
                        .IsRequired();
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Continent", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Currency", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("TravelBudgetDBModels.Models.Travel", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
