using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Models;

namespace Tournament.Data
{
    public class MockTournamentRepo : ITournamentRepo
    {
        List<Team> _teams = new List<Team>()
        {
            new Team(){ID = 1 , Name = "LA Lakers", Coach = "XY", State = "California"},
            new Team(){ID = 2 , Name = "LA Clippers", Coach = "XYZ", State = "California"},

        };

        public Team CreateTeam(Team team)
        {
            throw new NotImplementedException();
        }



        //List<Team> _teams;


        public Team GetTeam(int id)
        {
            return _teams.FirstOrDefault(t => t.ID == id);
            //return new Team() { ID = 1, Name = "LA Lakers", Coach = "XY", State = "California" };
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teams;

            //var teams = new List<Team>()
            //{
            //    new Team(){ID = 1 , Name = "LA Lakers", Coach = "XY", State = "California"},
            //};

            //return teams;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }


    }
}
