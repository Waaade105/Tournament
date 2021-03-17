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
        void UpdateTeam(Team team);
        void PartialUpdateTeam(Team team);
        void DeleteTeam(Team team);

        //GAME
        Game GetGame(int id);
        IEnumerable<Game> GetAllPlayedGames();
        void CreateGame(Game game);
        void DeleteGame(Game game);



    }
}
