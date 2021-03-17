using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.Models
{
    public class Game
    {
        
        public int ID { get; set; }
        [Required]
        public DateTime  Date { get; set; }
        public int NumberOfSpectators { get; set; }
        [Required]
        public Team Team_A { get; set; }
        //public Team TeamA { get; set; }    //TeamA czytalo do bazy tylko TeamAID = 1 np. i w api zwracalo nulle // chyba dlatego ze obiekt 
        [Required]
        public Team Team_B { get; set; }

        //public Team TeamB { get; set; }
        [Required]
        public int TeamA_score { get; set; }
        [Required]
        public int TeamB_score { get; set; }
        public Team Winner { get; set; } // automat zrobic   // losowanie druzyn zrobic

        //public List<int> GameResult { get; set; }
        public Game()
        {

        }
        //public Game(int id, DateTime date)
        //{
        //    this.ID = ID;
        //    teamA = tea

        //}

    }
}
