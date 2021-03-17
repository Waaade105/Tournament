using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Data;
using Tournament.DTOs;
using Tournament.Models;

namespace Tournament.Controllers
{
    [IgnoreAntiforgeryToken]
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ITournamentRepo _repo;
        private readonly IMapper _mapper;

        public GameController(ITournamentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/game/{id}
        [HttpGet("{id}", Name = "GetGame")]
        public ActionResult<GameReadDto> GetGame(int id)
        {           
            var game = _repo.GetGame(id);
            if(game == null)
            {
                return NotFound(game);
            }
            var gameDto = _mapper.Map<GameReadDto>(game);
            return Ok(gameDto);
        }



        //GET api/game
        [HttpGet]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGames()
        {
            var games = _repo.GetAllPlayedGames();
            if (!games.Any())
            {
                return NotFound(games);
            }
            var gamesDto = _mapper.Map<IEnumerable<GameReadDto>>(games);
            return Ok(gamesDto);
        }


        //POST api/game
        [HttpPost]
        public ActionResult CreateGame(GameCreateUpdateDto gameCreateUpdateDto) 
        {
            var model = _mapper.Map<Game>(gameCreateUpdateDto);

            if(model == null)
            {
                return NotFound(model);
            }

            _repo.CreateGame(model);
            _repo.SaveChanges();


            var gameReadDto =  _mapper.Map<GameReadDto>(model);

            return CreatedAtRoute(nameof(GetGame), new { Id = model.ID }, gameReadDto);
        }

        //PUT api/game/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGame(int id, GameCreateUpdateDto gameCreateUpdateDto)
        {
            //var model = _mapper.Map<Game>(gameCreateUpdateDto);
            var model = _repo.GetGame(id);
            if(model == null)
            {
                return NotFound(model);               
            }

            _mapper.Map(gameCreateUpdateDto, model);  
            _repo.SaveChanges();

            return NoContent();
        }

        public ActionResult PartialUpdate(int id, JsonPatchDocument<GameCreateUpdateDto> jsonPatchDocument)
        {
            var model = _repo.GetGame(id);
            if(model == null)
            {
                return NotFound(model);
            }

            var gameToPatch = _mapper.Map<GameCreateUpdateDto>(model);
            jsonPatchDocument.ApplyTo(gameToPatch, ModelState);
            if (!TryValidateModel(gameToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(gameToPatch, model);
            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/game/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            var model = _repo.GetGame(id);
            if(model == null)
            {
                return NotFound(model);
            }
            _repo.DeleteGame(model);
            _repo.SaveChanges();

            return NoContent();
            
        }






    }
}
