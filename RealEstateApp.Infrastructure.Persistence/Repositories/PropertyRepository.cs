using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Domain.Entities;
using RealEstateApp.Infrastructure.Persistence.Context;

namespace RealEstateApp.Infrastructure.Persistence.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public ApplicationDbContext _applicationContext;

        public PropertyRepository(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
