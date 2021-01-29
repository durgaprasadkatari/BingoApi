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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository<Player> _dataRepository;
        public PlayerController(IPlayerRepository<Player> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get(int playerid)
        {
            var bingoPlayers = _dataRepository.GetAll(playerid);
            return Ok(bingoPlayers);
        }

        // GET: api/Player/Guid
        [HttpGet("{id}", Name = "GetPlayer")]
        public IActionResult Get(Guid id)
        {
            var bingoPlayer = _dataRepository.Get(id);
            if (bingoPlayer == null)
            {
                return NotFound("Player not found.");
            }

            return Ok(bingoPlayer);
        }

        // POST: api/Player
        [HttpPost]
        public IActionResult Post([FromBody] Player player)
        {
            if (player is null)
            {
                return BadRequest("player is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Guid playerId = _dataRepository.Add(player);
            return Ok(new { PlayerId = playerId });
        }
    }
}
