using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Agent;
using RealEstateApp.Core.Application.Dtos.Property;
using RealEstateApp.Core.Application.Features.Agent.Commands.ChangeAgentStatus;
using RealEstateApp.Core.Application.Features.Agent.Queries.GetAgentById;
using RealEstateApp.Core.Application.Features.Agent.Queries.GetAgentPropertyById;
using RealEstateApp.Core.Application.Features.Agent.Queries.GetAllAgents;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using WebAPI.RealEstateApp.Controllers;

namespace WebApi.RealEstateApp.Controllers.v1
{

    [ApiVersion("1.0")]
    [SwaggerTag("Mantenimiento Agentes")]
    public class AgentController : BaseApiController
    {

        [Authorize(Roles = "Admin,SuperAdmin,Developer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AgentDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Listado de Agentes",
            Description = "Obtiene todos los agentes registrados"
         )]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllAgentsQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,SuperAdmin,Developer")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Listado de Agentes por ID",
            Description = "Obtiene un agente por ID"
         )]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetAgentByIdQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPut("ChangeState/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Estado del Agente",
            Description = "Activar o Desactivar estado del agente"
         )]
        public async Task<IActionResult> ChangeState(string id, [FromBody] ChangeAgentStatusCommand command)
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

        [Authorize(Roles = "Admin,SuperAdmin,Developer")]
        [HttpGet("GetAgentProperty/{agentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PropertyDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Listado de Propiedades de Agentes",
            Description = "Obtiene las Propiedades de un Agente"
         )]
        public async Task<IActionResult> GetAgentProperty(string agentId)
        {

            try
            {
                return Ok(await Mediator.Send(new GetAgentPropertyByIdQuery { AgentId = agentId }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
