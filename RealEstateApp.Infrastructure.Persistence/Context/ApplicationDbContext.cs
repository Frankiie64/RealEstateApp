using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Domain.Common;
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
                        entry.Entity.LastModifiedBy = user.Username;
                        break;
                    case EntityState.Added:
                        entry.Entity.Creadted = DateTime.Now;
                        entry.Entity.CreatedBy = user.Username;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region Table



            #endregion

            #region constraint

            #region Primary Key

    


            #endregion

            #region Relationships




            #endregion


            #endregion

            #region "Validation Required"

            
            #endregion
        }
    }
}