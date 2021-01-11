using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.TicketTypes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypesController
    {
       private readonly IMediator _mediator;
        public TicketTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketType>>> List()
        {
            return await _mediator.Send(new List.Query());
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketType>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query{Id=id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromForm]Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id,[FromForm]Edit.Command command1) 
        {
            command1.Id=id;
            return await _mediator.Send(command1);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command{Id=id});
        }
    }
}