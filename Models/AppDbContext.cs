using API_Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestLink> InterestLinks { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //User Seed
            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "Peter", LastName = "Ingvarsson", Phone = "070252542"});
            modelBuilder.Entity<User>().HasData(new User { Id = 2, FirstName = "Adrian", LastName = "Lundell", Phone = "070632175"});
            modelBuilder.Entity<User>().HasData(new User { Id = 3, FirstName = "Sam", LastName = "Svensson", Phone = "070154323"});

            modelBuilder.Entity<UserInterest>().HasData(new UserInterest { UserInterestID = 1, UserID = 1, InterestID = 1, InterestLinkID = 1 });
            modelBuilder.Entity<UserInterest>().HasData(new UserInterest { UserInterestID = 2, UserID = 2, InterestID = 2, InterestLinkID = 2 });
            modelBuilder.Entity<UserInterest>().HasData(new UserInterest { UserInterestID = 3, UserID = 3, InterestID = 3, InterestLinkID = 3 });
            modelBuilder.Entity<UserInterest>().HasData(new UserInterest { UserInterestID = 4, UserID = 3, InterestID = 4, InterestLinkID = 4 });

            //Interest Seed
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 1,
                Name = "Skateboarding",
                InterestDesc = "Skateboarding"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 2,
                Name = "Computers",
                InterestDesc = "Developing Software on the computer"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 3,
                Name = "Surfing",
                InterestDesc = "Riding a board on waves in the water"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 4,
                Name = "Snowboarding",
                InterestDesc = "Riding a board on snow"
            });

            //InterestLinks Seed
            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkID = 1,
                Link = "https://en.wikipedia.org/wiki/Skateboarding",

            });
            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkID = 2,
                Link = "https://www.ibm.com/topics/software-development",

            });
            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkID = 3,
                Link = "https://en.wikipedia.org/wiki/Surfing"
            });
            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkID = 4,
                Link = "https://en.wikipedia.org/wiki/Snowboarding",
            });
        }
    }
}
