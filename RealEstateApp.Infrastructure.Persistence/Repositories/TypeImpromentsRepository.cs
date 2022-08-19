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
    class TypeImpromentsRepository : GenericRepository<TypeImproments>, ITypeImpromentRepository
    {
        public ApplicationDbContext _applicationContext;

        public TypeImpromentsRepository(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
