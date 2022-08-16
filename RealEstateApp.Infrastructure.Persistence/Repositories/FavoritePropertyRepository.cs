using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Domain.Entities;
using RealEstateApp.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Persistence.Repositories
{
    public class FavoritePropertyRepository : GenericRepository<FavoriteProperty>, IFavoritePropertyRepository
    {
        public ApplicationDbContext _applicationContext;
        public FavoritePropertyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationContext = applicationDbContext;
        }
    }
}
