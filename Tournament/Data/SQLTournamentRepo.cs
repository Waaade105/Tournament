using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Models;

namespace Tournament.Data
{
    public class SQLTournamentRepo : ITournamentRepo
    {
        private readonly TournamentContext _context;

        public SQLTournamentRepo(TournamentContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        
        //Team methods
        public Team GetTeam(int id)
        {

            var team =  _context.Teams.FirstOrDefault(t => t.ID == id);
            if(team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            return team;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        public void CreateTeam(Team team)
        {
            if(team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            _context.Teams.Add(team);
        }

        public void UpdateTeam(Team team)
        {
            //
        }

        public void PartialUpdateTeam(Team team)
        {
            //
        }

        public void DeleteTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            _context.Teams.Remove(team);
        }

        //GAME
        
        public Game GetGame(int id)
        {
            //var x = _context.Games.Where(g => g.ID == id).Include(g => g.Team_A).ToList();

            var game = _context.Games.Where(g => g.ID == id).Include(t => t.Team_A)
                                                         .Include(t => t.Team_B)
                                                         .FirstOrDefault();
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            //return _context.Games.FirstOrDefault(g => g.ID == id);
            return game;


        }

        
        public IEnumerable<Game> GetAllPlayedGames()
        {

            var games = _context.Games.Include(team => team.Team_A)
                                        .Include(team => team.Team_B).ToList();
            //return _context.Games.ToList();
            return games;
        }

        public void CreateGame(Game createdGame)
        {
            if(createdGame == null)
            {
                throw new ArgumentNullException(nameof(createdGame));
            }
            _context.Add(createdGame);
        }

        public void DeleteGame(Game game)
        {
            if(game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            _context.Remove(game);
        }
    }
}
