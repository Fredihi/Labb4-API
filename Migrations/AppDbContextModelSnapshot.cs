﻿// <auto-generated />
using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Models.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestID"));

                    b.Property<string>("InterestDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestID");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestID = 1,
                            InterestDesc = "Skateboarding",
                            Name = "Skateboarding"
                        },
                        new
                        {
                            InterestID = 2,
                            InterestDesc = "Developing Software on the computer",
                            Name = "Computers"
                        },
                        new
                        {
                            InterestID = 3,
                            InterestDesc = "Riding a board on waves in the water",
                            Name = "Surfing"
                        },
                        new
                        {
                            InterestID = 4,
                            InterestDesc = "Riding a board on snow",
                            Name = "Snowboarding"
                        });
                });

            modelBuilder.Entity("API_Models.InterestLink", b =>
                {
                    b.Property<int>("InterestLinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestLinkID"));

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserInterestID")
                        .HasColumnType("int");

                    b.HasKey("InterestLinkID");

                    b.HasIndex("UserInterestID");

                    b.ToTable("InterestLinks");

                    b.HasData(
                        new
                        {
                            InterestLinkID = 1,
                            Link = "https://en.wikipedia.org/wiki/Skateboarding",
                            UserInterestID = 1
                        },
                        new
                        {
                            InterestLinkID = 2,
                            Link = "https://www.ibm.com/topics/software-development",
                            UserInterestID = 2
                        },
                        new
                        {
                            InterestLinkID = 3,
                            Link = "https://en.wikipedia.org/wiki/Surfing",
                            UserInterestID = 3
                        },
                        new
                        {
                            InterestLinkID = 4,
                            Link = "https://en.wikipedia.org/wiki/Snowboarding",
                            UserInterestID = 4
                        });
                });

            modelBuilder.Entity("API_Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Peter",
                            LastName = "Ingvarsson",
                            Phone = "070252542"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Adrian",
                            LastName = "Lundell",
                            Phone = "070632175"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Sam",
                            LastName = "Svensson",
                            Phone = "070154323"
                        });
                });

            modelBuilder.Entity("API_Models.UserInterest", b =>
                {
                    b.Property<int>("UserInterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserInterestID"));

                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserInterestID");

                    b.HasIndex("InterestID");

                    b.HasIndex("UserID");

                    b.ToTable("UserInterests");

                    b.HasData(
                        new
                        {
                            UserInterestID = 1,
                            InterestID = 1,
                            UserID = 1
                        },
                        new
                        {
                            UserInterestID = 2,
                            InterestID = 2,
                            UserID = 2
                        },
                        new
                        {
                            UserInterestID = 3,
                            InterestID = 3,
                            UserID = 3
                        },
                        new
                        {
                            UserInterestID = 4,
                            InterestID = 4,
                            UserID = 3
                        });
                });

            modelBuilder.Entity("API_Models.InterestLink", b =>
                {
                    b.HasOne("API_Models.UserInterest", "UserInterest")
                        .WithMany()
                        .HasForeignKey("UserInterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInterest");
                });

            modelBuilder.Entity("API_Models.UserInterest", b =>
                {
                    b.HasOne("API_Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
