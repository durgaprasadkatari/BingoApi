using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bingo.Api.Models;
using Bingo.Api.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository<Ticket> _dataRepository;
        public TicketController(ITicketRepository<Ticket> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Ticket/Guid
        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult Get(Guid id)
        {
            var bingoTicket = _dataRepository.Get(id);
            if (bingoTicket == null)
            {
                return NotFound("Ticket not found.");
            }

            return Ok(bingoTicket);
        }

        // POST: api/Ticket
        [HttpPost]
        public IActionResult Post([FromBody] Ticket ticket)
        {
            if (ticket is null)
            {
                return BadRequest("ticket is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bingoTicket = _dataRepository.GetExistingTicket(ticket.Playerid, ticket.Gameid);
            if (bingoTicket.Count() > 0)
            {
                return BadRequest("Ticket has been already created for this player.");
            }
            ticket = _dataRepository.Add(ticket);
            return Ok(ticket);
        }

        public IActionResult Get(Guid playerid, int gameid)
        {
            var bingoTicket = _dataRepository.GetExistingTicket(playerid, gameid);
            if (bingoTicket.Count() == 0)
            {
                return NotFound("Ticket not found.");
            }

            return Ok(bingoTicket);
        }
    }
}
