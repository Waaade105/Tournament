using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {

        private readonly ITournamentRepo _repo;
        private readonly IMapper _mapper;

        public TeamController(ITournamentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/team/{id}
        [HttpGet("{id}", Name = "GetTeam")]
        public ActionResult<TeamReadDto> GetTeamById(int id)
        {
            var team = _repo.GetTeam(id);
            if (team != null)
            {
                var teamDto = _mapper.Map<TeamReadDto>(team);
                return Ok(teamDto);

            }
            return NotFound(team);
        }

        //GET api/team
        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeams()
        {
            var allTeams = _repo.GetTeams();
            var teamsDto = _mapper.Map<IEnumerable<TeamReadDto>>(allTeams);
            return Ok(teamsDto);
        }

        //POST api/team
        [HttpPost]
        public ActionResult<TeamReadDto> AddTeam(TeamCreateUpdateDto teamCreateUpdateDto)
        {
            var model = _mapper.Map<Team>(teamCreateUpdateDto);

            if (model == null)
            {
                return NotFound(model);
            }

            _repo.CreateTeam(model);
            _repo.SaveChanges();

            var teamReadDto = _mapper.Map<TeamReadDto>(model);

            return CreatedAtRoute(nameof(GetTeamById), new { Id = model.ID }, teamReadDto);   
        }

        //PUT api/team/{id} 
        [HttpPut("{id}")]
        public ActionResult UpdateTeam(int id, TeamCreateUpdateDto teamCreateUpdateDto)
        {
            var model = _repo.GetTeam(id);
            if (model == null)
            {
                NotFound(model);
            }
            
            _mapper.Map(teamCreateUpdateDto, model);
            _repo.SaveChanges();

            return NoContent();
        }

        //PATCH api/team/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateTeam(int id, JsonPatchDocument<TeamCreateUpdateDto> patchDocument)
        {
            var model = _repo.GetTeam(id);
            if(model == null)
            {
                return NotFound(model);
            }

            var teamToPatch = _mapper.Map<TeamCreateUpdateDto>(model);
            patchDocument.ApplyTo(teamToPatch, ModelState);

            if (!TryValidateModel(teamToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(teamToPatch, model);
            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/team/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTeam(int id)
        {
            var modelToDelete = _repo.GetTeam(id);
            if(modelToDelete == null)
            {
                return NotFound(modelToDelete);
            }

            _repo.DeleteTeam(modelToDelete);
            _repo.SaveChanges();

            return NoContent();
        }


    }
}
//public List<Team> Teams { get; set; }
//    = new List<Team>();
//public List<Team> PlayingTeams { get; set; }
//            = new List<Team>();

