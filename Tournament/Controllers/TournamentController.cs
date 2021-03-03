using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Data;
using Tournament.DTOs;
using Tournament.Models;

namespace Tournament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : Controller
    {
        //public List<Team> Teams { get; set; }
        //    = new List<Team>();
        //public List<Team> PlayingTeams { get; set; }
        //            = new List<Team>();



        private readonly ITournamentRepo _repo;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<TeamReadDto> GetTeamById(int id)
        {
            var team = _repo.GetTeam(id);
            if(team != null)
            {
                var teamDto = _mapper.Map<TeamReadDto>(team);
                return Ok(teamDto);

            }
            return NotFound(team);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeams()
        {
            var allTeams = _repo.GetTeams();
            var teamsDto = _mapper.Map<IEnumerable<TeamReadDto>>(allTeams);
            return Ok(teamsDto);
        }

        [HttpPost]
        public ActionResult<TeamReadDto> AddTeam(TeamCreateDto teamCreateDto)
        {
            if(teamCreateDto == null)
            {
                throw new ArgumentNullException(nameof(teamCreateDto));
            }

            var model = _mapper.Map<Team>(teamCreateDto);
       
            _repo.CreateTeam(model);
            _repo.SaveChanges();

            return Ok(model);
        }




        //[HttpGet("Game/{id}")]
        //public ActionResult<Game> GetGameById(int id)
        //{

        //    var game = _repo.GetGame(id);
        //    if (game == null)
        //    {
        //        return NotFound(game);
        //    }

            
        //    return Ok(game);
        //}



        [HttpGet("Game/{id}")]
        //Game
        public ActionResult<GameReadDto> GetGameById(int id)
        {
            
            var game = _repo.GetGame(id);
            var team1_id = game.Team_A;
            var team2_id = game.Team_B;


            var searchedTeam1 = _repo.GetTeam(team1_id);
            var searchedTeam2 = _repo.GetTeam(team2_id);

            var gameWithAllData = new Game()
            {
                Date = game.Date,
                Team_A = searchedTeam1.Name,

            }



            if (game == null)
            {
                return NotFound(game);
            }

            var gameDto = _mapper.Map<GameReadDto>(game);
            return Ok(gameDto);
        }
        [HttpGet("Game")]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGames()
        {
            var games = _repo.GetAllPlayedGames();
            var gamesDto = _mapper.Map<IEnumerable<GameReadDto>>(games);   // nie chce zeby user widzial ID teamu lecz nazwe 

            return Ok(gamesDto);
        }
    }
}
