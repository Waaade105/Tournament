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
        public DateTime  Date { get; set; } // zmienna datowa
        [Required]
        public Team teamA { get; set; }
        [Required]
        public Team teamB { get; set; }
        [Required]
        public int TeamA_score { get; set; }
        [Required]
        public int TeamB_score { get; set; }
        public Team Winner { get; set; } // automat zrobic   // losowanie druzyn zrobic

        //public List<int> GameResult { get; set; }
        public Game()
        {

        }

    }
}
