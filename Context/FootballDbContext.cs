using FootballAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballAPI.Context
{
    public partial class FootballDbContext : DbContext
    {
        public FootballDbContext()
        {
        }

        public FootballDbContext(DbContextOptions<FootballDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Stadium> Stadiums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<Player>()
            //    .HasOne(a => a.Team);

            //    modelBuilder.Entity<Team>()
            //    .HasOne(a => a.Stadium);

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.Height).IsRequired();
                entity.Property(e => e.Weight).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.TeamId);
                entity.Property(e => e.IsActive).IsRequired();
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Manager).IsRequired();
                entity.Property(e => e.StadiumId);
                entity.Property(e => e.IsActive).IsRequired();
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Capacity).IsRequired();
                entity.Property(e => e.AddressLine1).IsRequired();
                entity.Property(e => e.AddressLine2);
                entity.Property(e => e.Suburb).IsRequired();
                entity.Property(e => e.Province).IsRequired();
                entity.Property(e => e.PostalCode).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();
            });

        }
    }
}
