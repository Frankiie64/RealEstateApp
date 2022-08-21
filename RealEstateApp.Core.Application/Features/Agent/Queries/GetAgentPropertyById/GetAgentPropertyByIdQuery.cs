using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Agent;
using RealEstateApp.Core.Application.Dtos.Improvement;
using RealEstateApp.Core.Application.Dtos.Property;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Dtos.TypeSale;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Agent.Queries.GetAgentPropertyById
{
    public class GetAgentPropertyByIdQuery : IRequest<IEnumerable<PropertyDto>>
    {
        public string AgentId { get; set; }
    }

    public class GetAgentPropertyByIdQueryHandler : IRequestHandler<GetAgentPropertyByIdQuery, IEnumerable<PropertyDto>>
    {
        private readonly IAccountServices _accountServices;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IImprovementRepository _improvementRepository;
        private readonly ITypeImpromentRepository _typeImpromentRepository;
        private readonly IMapper _mapper;

        public GetAgentPropertyByIdQueryHandler
            (IAccountServices accountServices,
            IPropertyRepository propertyRepository,
            IMapper mapper,
            IImprovementRepository improvementRepository,
            ITypeImpromentRepository typeImpromentRepository
            )
        {
            _accountServices = accountServices;
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _improvementRepository = improvementRepository;
            _typeImpromentRepository = typeImpromentRepository;
        }

        public async Task<IEnumerable<PropertyDto>> Handle(GetAgentPropertyByIdQuery query, CancellationToken cancellationToken)
        {

            return await GetAllAgentPropertyDto(query.AgentId);

        }

        private async Task<List<PropertyDto>> GetAllAgentPropertyDto(string userId)
        {

            var agents = await _accountServices.GetAllUsersAsync();

            var agent = await _accountServices.GetUserByIdAsync(userId);

            List<PropertyDto> properties = _mapper.Map<List<PropertyDto>>(await _propertyRepository.GetAllWithIncludeAsync(new List<string> { "TypeProperty", "TypeSale", "Improments" }));
            if (properties.Where(property => property.AgentId == agent.Id).Count() <= 0) throw new Exception($"Este Agente no tiene propiedades");

            var improvements = await _improvementRepository.GetAllWithIncludeAsync(new List<string> { "typeImproments" });
            var typeImprovements = await _typeImpromentRepository.GetAllAsync();


            return properties.Where(property => property.AgentId == agent.Id).Select(property => new PropertyDto
            {
                Code = property.Code,
                Location = property.Location,
                Id = property.Id,
                Room = property.Room,
                Price = property.Price,
                Description = property.Description,
                Meters = property.Meters,
                Bathroom = property.Bathroom,
                AgentId = property.AgentId,
                TypeProperty = _mapper.Map<TypePropertyDto>(property.TypeProperty),
                TypeSale = _mapper.Map<TypeSaleDto>(property.TypeSale),
                AgentName = agents.FirstOrDefault(x => x.Id == property.AgentId).Firstname + " " + agents.FirstOrDefault(x => x.Id == property.AgentId).Lastname,
                Improvements = _mapper.Map<List<ImprovementDto>>(typeImprovements.Where(x => x.IdProperty == property.Id).Select(typeImprovement => new ImprovementDto
                {
                    Id = typeImprovement.IdImproment,
                    Name = typeImprovement.Improvement.Name,
                    Description = typeImprovement.Improvement.Description
                })).ToList()

            }).ToList();
        }






    }


}
