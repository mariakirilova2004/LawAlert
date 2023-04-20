using LawAlert.Infrastructure.Data.Entities.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LawAlert.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using LawAlert.Infrastructure.Configurations;

namespace LawAlert.Infrastructure.Data
{
    public class LawAlertDbContext : IdentityDbContext<User>
    {
        private bool seedDb;

        public LawAlertDbContext(DbContextOptions<LawAlertDbContext> options, bool seed = true)
            : base(options)
        {
            this.seedDb = seed;
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Law> Laws { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (this.seedDb)
            {
                modelBuilder.ApplyConfiguration(new UserConfiguration());
                modelBuilder.ApplyConfiguration(new InterestConfiguration());
            }

            modelBuilder.Entity<User>()
               .HasKey(o => o.Id);

            modelBuilder.Entity<User>()
               .HasMany(u => u.Interests);

            modelBuilder.Entity<Law>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Law>()
               .HasMany(l => l.Chapters)
               .WithOne(c => c.Law)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Law>()
               .HasOne(l => l.Interest);


            modelBuilder.Entity<Chapter>()
               .HasOne(c => c.Law)
               .WithMany(l => l.Chapters)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chapter>()
               .HasKey(c => c.Id);

            modelBuilder.Entity<Chapter>()
               .HasMany(c => c.Articles)
               .WithOne(a => a.Chapter)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Chapter)
                .WithMany(c => c.Articles)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Article>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Chapter)
                .WithMany(c => c.Articles);

            modelBuilder.Entity<Article>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Point>()
                .HasOne(p => p.Article)
                .WithMany(a => a.Points);

            modelBuilder.Entity<Point>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Interest>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<PersonalData>()
                .HasKey(pd => pd.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}