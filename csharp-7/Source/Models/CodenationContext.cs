using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Challenge> Challenges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Submission>().HasOne<User>().WithMany().HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Candidate>();
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Acceleration>();
            modelBuilder.Entity<Challenge>().HasKey(c => c.Id);
        }
    }
}