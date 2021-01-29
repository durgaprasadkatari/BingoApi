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
    public class BingoBoardController : ControllerBase
    {
        private readonly IDataRepository<BingoBoard> _dataRepository;
        public BingoBoardController(IDataRepository<BingoBoard> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            var bingoBoards = _dataRepository.GetAll();
            return Ok(bingoBoards);
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetBoard")]
        public IActionResult Get(int id)
        {
            var bingoBoard = _dataRepository.Get(id);
            if (bingoBoard == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(bingoBoard);
        }

        // POST: api/Authors
        [HttpPost]
        public IActionResult Post([FromBody] BingoBoard board)
        {
            if (board is null)
            {
                return BadRequest("board is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int boardId = _dataRepository.Add(board);
            return Ok(new { BoardId = boardId });
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BingoBoard board)
        {
            if (board == null)
            {
                return BadRequest("board is null.");
            }

            var bingoBoardToUpdate = _dataRepository.Get(id);
            if (bingoBoardToUpdate == null)
            {
                return NotFound("The board record couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(bingoBoardToUpdate, board);
            return NoContent();
        }
    }
}
