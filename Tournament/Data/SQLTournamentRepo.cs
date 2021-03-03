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
            return _context.Teams.FirstOrDefault(t => t.ID == id);
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




        public Game GetGame(int id)
        {
            return _context.Games.FirstOrDefault(g => g.ID == id);
        }

        public IEnumerable<Game> GetAllPlayedGames()
        {
            return _context.Games.ToList();
        }


    }
}
