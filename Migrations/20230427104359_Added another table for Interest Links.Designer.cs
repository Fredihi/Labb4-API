﻿// <auto-generated />
using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230427104359_Added another table for Interest Links")]
    partial class AddedanothertableforInterestLinks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("InterestID");

                    b.HasIndex("UserID");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestID = 1,
                            InterestDesc = "Skateboarding",
                            Name = "Skateboarding",
                            UserID = 1
                        },
                        new
                        {
                            InterestID = 2,
                            InterestDesc = "Developing Software on the computer",
                            Name = "Computers",
                            UserID = 2
                        },
                        new
                        {
                            InterestID = 3,
                            InterestDesc = "Riding a board on waves in the water",
                            Name = "Surfing",
                            UserID = 3
                        },
                        new
                        {
                            InterestID = 4,
                            InterestDesc = "Riding a board on snow",
                            Name = "Snowboarding",
                            UserID = 3
                        });
                });

            modelBuilder.Entity("API_Models.InterestLink", b =>
                {
                    b.Property<int>("InterestLinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestLinkID"));

                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestLinkID");

                    b.HasIndex("InterestID");

                    b.ToTable("InterestLink");

                    b.HasData(
                        new
                        {
                            InterestLinkID = 1,
                            InterestID = 1,
                            Link = "https://en.wikipedia.org/wiki/Skateboarding"
                        },
                        new
                        {
                            InterestLinkID = 2,
                            InterestID = 2,
                            Link = "https://www.ibm.com/topics/software-development"
                        },
                        new
                        {
                            InterestLinkID = 3,
                            InterestID = 3,
                            Link = "https://en.wikipedia.org/wiki/Surfing"
                        },
                        new
                        {
                            InterestLinkID = 4,
                            InterestID = 4,
                            Link = "https://en.wikipedia.org/wiki/Snowboarding"
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

            modelBuilder.Entity("API_Models.Interest", b =>
                {
                    b.HasOne("API_Models.User", "User")
                        .WithMany("Interest")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API_Models.InterestLink", b =>
                {
                    b.HasOne("API_Models.Interest", "Interests")
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");
                });

            modelBuilder.Entity("API_Models.Interest", b =>
                {
                    b.Navigation("InterestLinks");
                });

            modelBuilder.Entity("API_Models.User", b =>
                {
                    b.Navigation("Interest");
                });
#pragma warning restore 612, 618
        }
    }
}
