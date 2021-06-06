using FootballAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.Height).IsRequired();
                entity.Property(e => e.Weight).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();
            });

            //modelBuilder.Entity<AssessingDiary>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.DiaryName).IsRequired();
            //    entity.Property(e => e.IsActive).IsRequired();
            //});

            //modelBuilder.Entity<AssessmentLocation>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.AssessmentLocationName).IsRequired();
            //    entity.Property(e => e.IsActive).IsRequired();
            //    entity.Property(e => e.IsSystemManaged).IsRequired();
            //});

            //modelBuilder.Entity<DiaryAssessmentLocation>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.DiaryId).IsRequired();
            //    entity.Property(e => e.AssessmentLocationId).IsRequired();
            //    entity.Property(e => e.IsActive).IsRequired();

            //});

            //modelBuilder.Entity<Assessor>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.AssessorName).IsRequired();
            //    entity.Property(e => e.IsActive).IsRequired();
            //});

            //modelBuilder.Entity<DiaryAssessor>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.AssessorId).IsRequired();
            //    entity.Property(e => e.DiaryId).IsRequired();
            //    entity.Property(e => e.IsActive).IsRequired();
            //});

            //modelBuilder.Entity<DiaryAssessorCapacity>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.DiaryAssessorId).IsRequired();
            //    entity.Property(e => e.EffectiveDate).IsRequired();
            //    entity.Property(e => e.NumberOfSlots).IsRequired();
            //});

            //modelBuilder.Entity<AssessmentBooking>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.BookingReference).IsRequired();
            //    entity.Property(e => e.DiaryAssessmentLocationId).IsRequired();
            //    entity.Property(e => e.EffectiveDate).IsRequired();
            //    entity.Property(e => e.IsActive).IsRequired();
            //    entity.Property(e => e.AssessorId);
            //    entity.Property(e => e.AssessmentTypeId).IsRequired();
            //});

            //modelBuilder.Entity<AssessmentType>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //    entity.Property(e => e.Description).IsRequired();
            //    entity.Property(e => e.IsActive).IsRequired();
            //});

            //modelBuilder.Entity<ServiceProviderAuthentication>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //    entity.Property(e => e.ApiKey).IsRequired();
            //    entity.Property(e => e.ServiceProviderId).IsRequired();
            //});

            //modelBuilder.Entity<ServiceProvider>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //    entity.Property(e => e.Description).IsRequired();
            //});
        }
    }
}
