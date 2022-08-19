using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Features.TypeProperties.Commands.CreateTypeProperty;
using RealEstateApp.Core.Application.Features.TypeProperties.Commands.DeleteTypePropertyById;
using RealEstateApp.Core.Application.Features.TypeProperties.Commands.UpdateTypeProperty;
using RealEstateApp.Core.Application.Features.TypeProperties.Queries.GetAllTypeProperties;
using RealEstateApp.Core.Application.Features.TypeProperties.Queries.GetTypePropertyById;
using RealEstateApp.Core.Application.Features.TypeSale.Queries.GetAllTypeProperties;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using WebAPI.RealEstateApp.Controllers;

namespace WebApi.RealEstateApp.Controllers.v1
{
    [ApiVersion("1.0")]
    [SwaggerTag("Mantenimiento Tipos de Propiedades")]
    public class TypePropertyController : BaseApiController
    {
        [Authorize(Roles = "Admin,SuperAdmin,Developer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypePropertyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Listado de Tipos de Propiedades",
            Description = "Obtener todas las Propiedades"
         )]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllTypePropertiesQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,SuperAdmin,Developer")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypePropertyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Tipos de Propiedades por Id",
            Description = "Obtener un Tipo Propiedad por Id"
         )]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetTypePropertyByIdQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Crear un Tipo de Propiedad",
            Description = "Recibe los parametros para crear un nuevo Tipo de Propiedad"
         )]
        public async Task<IActionResult> Post([FromBody] CreateTypePropertyCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveTypePropertyDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Actualizacion Tipo de Propiedad",
            Description = "Recibe los parametros para modificar un Tipo de Propiedad existente"
         )]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTypePropertyCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (id != command.Id)
                {
                    return BadRequest();
                }
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Eliminar un Tipo de Propiedad",
            Description = "Recibe los parametros para eliminar un Tipo de Propiedad"
         )]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteTypePropertyByIdCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
