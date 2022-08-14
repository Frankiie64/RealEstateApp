using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Domain.Entities;
using RealEstateApp.Infrastructure.Persistence.Context;

namespace RealEstateApp.Infrastructure.Persistence.Repositories
{
    public class PhotosPropertyRepository : GenericRepository<PhotosOfProperties>, IPhotosPropertyRepository
    {
        public ApplicationDbContext _applicationContext;
        public PhotosPropertyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationContext = applicationDbContext;
        }
    }
}
