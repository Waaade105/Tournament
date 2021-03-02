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

        

        public void CreateTeam(Team team)
        {
            if(team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            _context.Teams.Add(team);
        }


        public Team GetTeam(int id)
        {
            return _context.Teams.FirstOrDefault(t => t.ID == id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
            
            
        }
    }
}
