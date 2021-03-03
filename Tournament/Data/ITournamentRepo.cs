using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Models;

namespace Tournament.Data
{
    public interface ITournamentRepo
    {
        bool SaveChanges();
        Team GetTeam(int id);
        IEnumerable<Team> GetTeams();
        void CreateTeam(Team team); // na razie void


        Game GetGame(int id);
        IEnumerable<Game> GetAllPlayedGames();



    }
}
