using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Domain.Common;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AuthenticationResponse user;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<TypeProperty> TypeProperties { get; set; }
        public DbSet<TypeSale> TypeSales { get; set; }
        public DbSet<Improvement> Improvements { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                List<string> Rol = new();

                Rol.Add("SuperAdmin");

                user = new AuthenticationResponse
                {
                    Id = "01",
                    Username = "masterAdmin",
                    Email = "masterAdmin@gmail.com",
                    Roles = Rol,
                    IsVerified = true
                };
            }
            else
            {
                user = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            }

            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "user";
                        break;
                    case EntityState.Added:
                        entry.Entity.Creadted = DateTime.Now;
                        entry.Entity.CreatedBy = "user";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region Table


            modelBuilder.Entity<Property>()
                .ToTable("Properties");

            modelBuilder.Entity<TypeProperty>()
                .ToTable("TypeProperties");

            modelBuilder.Entity<TypeSale>()
                .ToTable("TypeSales");

            modelBuilder.Entity<Improvement>()
                .ToTable("Improvements");

            modelBuilder.Entity<PhotosOfProperties>()
          .ToTable("PhotosOfProperties");

            #endregion

            #region constraint

            #region Primary Key

            modelBuilder.Entity<Property>()
                .HasKey(property => property.Id);

            modelBuilder.Entity<TypeProperty>()
                .HasKey(typeProperty => typeProperty.Id);

            modelBuilder.Entity<TypeSale>()
                .HasKey(typeSale => typeSale.Id);

            modelBuilder.Entity<Improvement>()
                .HasKey(improvement => improvement.Id);

                modelBuilder.Entity<PhotosOfProperties>()
          .HasKey(photosOfProperties => photosOfProperties.Id);


            #endregion


            #region Relationships


            modelBuilder.Entity<TypeProperty>()
         .HasMany<Property>(typeProperty => typeProperty.Properties)
         .WithOne(property => property.TypeProperty)
         .HasForeignKey(property => property.TypePropertyId)
         .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            modelBuilder.Entity<TypeSale>()
         .HasMany<Property>(typeSale => typeSale.Properties)
         .WithOne(property => property.TypeSale)
         .HasForeignKey(property => property.TypeSaleId)
         .OnDelete(deleteBehavior: DeleteBehavior.Cascade);


            modelBuilder.Entity<Property>()
                .HasMany(photos => photos.UrlPhotos)
                .WithOne(property => property.Property)
                .HasForeignKey(idProperty => idProperty.IdProperty)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            modelBuilder.Entity<Property>()
          .HasMany(property => property.Improvements)
          .WithOne(improvement => improvement.Property)
          .HasForeignKey(improvement => improvement.IdProperty)
          .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            /*
            modelBuilder.Entity<Property>()
                .HasMany(property => property.Improvements)
                .WithMany(improvement => improvement.Properties)
                .UsingEntity<PropertyImprovement>(
                    j => j
                        .HasOne(propertyImprovement => propertyImprovement.Improvement)
                        .WithMany(improvement => improvement.PropertyImprovements)
                        .HasForeignKey(propertyImprovement => propertyImprovement.PropertyId),
                    j => j
                        .HasOne(propertyImprovement => propertyImprovement.Property)
                        .WithMany(property => property.PropertyImprovements)
                        .HasForeignKey(propertyImprovement => propertyImprovement.ImprovementId),
                    j =>
                    {
                        j.ToTable("PropertyImprovement");
                        j.HasKey(e => new { e.PropertyId, e.ImprovementId });
                    });
            */

            #endregion


            #region "Validation Required"

            #region Property
            modelBuilder.Entity<Property>()
                .Property(a => a.Code)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Property>()
                .Property(a => a.Description)
                .IsRequired();

            modelBuilder.Entity<Property>()
                .Property(a => a.Price)
                .IsRequired();

            modelBuilder.Entity<Property>()
                .Property(a => a.Meters)
                .IsRequired();

            modelBuilder.Entity<Property>()
                .Property(a => a.Bathroom)
                .IsRequired();

            modelBuilder.Entity<Property>()
                .Property(a => a.AgentId)
                .IsRequired();

            modelBuilder.Entity<Property>()
                .Property(a => a.TypePropertyId)
                .IsRequired();

            modelBuilder.Entity<Property>()
                .Property(a => a.TypeSaleId)
                .IsRequired();
            #endregion


            #region TypeProperty
            modelBuilder.Entity<TypeProperty>()
                .Property(a => a.Name)
                .IsRequired();

            modelBuilder.Entity<TypeProperty>()
                .Property(a => a.Description)
                .IsRequired();
            #endregion



            #region TypeSale

            modelBuilder.Entity<TypeSale>()
                .Property(a => a.Name)
                .IsRequired();

            modelBuilder.Entity<TypeSale>()
                .Property(a => a.Description)
                .IsRequired();

            #endregion


            #region Improvement
            modelBuilder.Entity<Improvement>()
                .Property(a => a.Name)
                .IsRequired();

            modelBuilder.Entity<Improvement>()
                .Property(a => a.Description)
                .IsRequired();

            #endregion

            #region PhotosOfProperty

            modelBuilder.Entity<PhotosOfProperties>()
                .Property(a => a.ImagUrl)
                .IsRequired();

            modelBuilder.Entity<PhotosOfProperties>()
                .Property(a => a.IdProperty)
                .IsRequired();
            #endregion


            #endregion


            #endregion

        }
    }
}