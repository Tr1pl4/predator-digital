using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.PredatorBG.Dto;
using WebAPI.PredatorBG.Models;
using WebAPI.PredatorBG.Services;

namespace WebAPI.PredatorBG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LobbiesController : ControllerBase
    {
        private readonly IPredatorBGService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public LobbiesController(IPredatorBGService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/Lobbies
        [HttpGet]
        public async Task<IActionResult> GetLobbies()
        {
            var lobbies = await _service.GetLobbies();
            return Ok(lobbies);
        }

        // GET: api/Lobbies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLobby(int id)
        {
            try
            {
                var lobby = await _service.GetLobbyById(id);
                return Ok(lobby);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // PUT: api/Lobbies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLobby(int id, LobbyDto lobby)
        {
            {
                if (id != lobby.Id)
                {
                    return BadRequest();
                }
                var result = await _service.UpdateLobby((Lobby)lobby);

                if (result != 0)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        // POST: api/Lobbies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<LobbyDto>> PostLobby(LobbyDto lobbyDto)
        {
            var lobby = (Lobby)lobbyDto;
            var result = await _service.CreateLobby(lobby);
            if (result != 0)
            {
                return CreatedAtAction(nameof(GetLobby), new { id = lobby.Id }, (LobbyDto)lobby);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        // DELETE: api/Lobbies/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLobby(int id)
        {
            var result = await _service.DeleteLobby(id);

            if (result != 0)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
