using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Reports;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReportsControllers:BaseController
    {
          [HttpGet]
        public async Task<ActionResult<List<Report>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Report>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id=id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id,[FromForm]Edit.Command command1) 
        {
            command1.Id=id;
            return await Mediator.Send(command1);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command{Id=id});
        }
    }
}