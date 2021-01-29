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
    public class GameController : ControllerBase
    {
        private readonly IGameRepository<GameDetails> _dataRepository;
        public GameController(IGameRepository<GameDetails> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Ticket/Guid
        [HttpGet("{id}", Name = "GetGameDetails")]
        public IActionResult Get(int id)
        {
            var bingoGame = _dataRepository.Get(id);
            if (bingoGame == null)
            {
                return NotFound("Game not found.");
            }

            return Ok(bingoGame);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GameDetails gameDetails)
        {
            if (gameDetails is null)
            {
                return BadRequest("Game is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            gameDetails = _dataRepository.Add(gameDetails);
            return Ok(gameDetails);
        }

        [HttpPut]
        public IActionResult Put([FromBody] GameDetails gameDetails)
        {
            if (gameDetails is null)
            {
                return BadRequest("Game is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(gameDetails);
            return Ok(new { responseMessage = "Updated successfully." });
        }
    }
}
