using AngularDotNetProject.Domain.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    
namespace AngularDotNetProject.Repository.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Event> Events { get; set; }
        public DbSet<Headline> Headlines { get; set; }
        public DbSet<HeadlineEvent> HeadlineEvents { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HeadlineEvent>()
                .HasKey(PE => new { PE.EventId, PE.HeadlineId });
        }

    }
}
