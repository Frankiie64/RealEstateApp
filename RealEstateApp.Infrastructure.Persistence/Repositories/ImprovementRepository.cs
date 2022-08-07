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
    public class ImprovementRepository : GenericRepository<Improvement>, IImprovementRepository
    {

        public ApplicationDbContext _applicationContext;

        public ImprovementRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationContext = applicationDbContext;
        }
    }

}
