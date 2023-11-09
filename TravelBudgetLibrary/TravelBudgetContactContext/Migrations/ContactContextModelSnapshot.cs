﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBudgetContactContext;

#nullable disable

namespace TravelBudgetContactContext.Migrations
{
    [DbContext(typeof(ContactContext))]
    partial class ContactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("TravelBudgetModels.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                            Type = "Atractions"
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

            modelBuilder.Entity("TravelBudgetModels.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("TravelBudgetModels.Models.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("TravelBudgetModels.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("TravelBudgetModels.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("TravelBudgetModels.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

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
                            CountryId = 1,
                            Date = new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            Description = "I bought a souvenir",
                            Price = 15.5,
                            TravelId = 1
                        });
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

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
                            FinishDate = new DateTime(2022, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified),
                            Name = "Around Poland",
                            StartingDate = new DateTime(2022, 12, 16, 6, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CommentId = 2,
                            Description = "Visiting forests",
                            FinishDate = new DateTime(2023, 10, 12, 21, 15, 0, 0, DateTimeKind.Unspecified),
                            Name = "Around Poland",
                            StartingDate = new DateTime(2023, 9, 18, 6, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CommentId = 3,
                            Description = "Mazurian lakes",
                            FinishDate = new DateTime(2023, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified),
                            Name = "Around Poland",
                            StartingDate = new DateTime(2023, 6, 18, 6, 15, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CountryTravel", b =>
                {
                    b.HasOne("TravelBudgetModels.Models.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetModels.Models.Travel", null)
                        .WithMany()
                        .HasForeignKey("TravelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Country", b =>
                {
                    b.HasOne("TravelBudgetModels.Models.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetModels.Models.Currency", "Currency")
                        .WithMany("Countries")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Expense", b =>
                {
                    b.HasOne("TravelBudgetModels.Models.Category", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetModels.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBudgetModels.Models.Travel", "Travel")
                        .WithMany("Expenses")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Travel", b =>
                {
                    b.HasOne("TravelBudgetModels.Models.Comment", "Comment")
                        .WithOne("Travel")
                        .HasForeignKey("TravelBudgetModels.Models.Travel", "CommentId");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Category", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Comment", b =>
                {
                    b.Navigation("Travel")
                        .IsRequired();
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Continent", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Currency", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("TravelBudgetModels.Models.Travel", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
