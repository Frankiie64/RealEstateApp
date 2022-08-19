using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Property;
using RealEstateApp.Core.Application.Features.Properties.Queries.GetAllProperties;
using RealEstateApp.Core.Application.Features.Properties.Queries.GetPropertyByCode;
using RealEstateApp.Core.Application.Features.Properties.Queries.GetPropertyById;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using WebAPI.RealEstateApp.Controllers;

namespace WebApi.RealEstateApp.Controllers.v1
{
    [Authorize(Roles = "Admin,SuperAdmin,Developer")]
    [ApiVersion("1.0")]
    [SwaggerTag("Mantenimiento Propiedades")]
    public class PropertyController : BaseApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Listado de Propiedades",
            Description = "Obtener todas las Propiedades"
         )]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllPropertiesQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Propiedades por Id",
            Description = "Obtener una propiedad por Id"
         )]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetPropertyByIdQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetPropertyByCode/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Mejoras por Codigo",
            Description = "Obtener una propiedad por Codigo"
         )]
        public async Task<IActionResult> GetByCode(int code)
        {
            try
            {
                return Ok(await Mediator.Send(new GetPropertyByCodeQuery { Code = code }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




    }
}
