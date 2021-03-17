using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Models;

namespace Tournament.DTOs
{
    public class GameCreateUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; } // zmienna datowa
        [Required]
        [MaxLength(50)]
        public Team Team_A { get; set; } // w bazie TeamAID
        [Required]
        [MaxLength(50)]
        public Team Team_B { get; set; } // w bazie TeamBID
        [Required]
        [MaxLength(3)]
        public int TeamA_score { get; set; }
        [Required]
        [MaxLength(3)]
        public int TeamB_score { get; set; }
        [Required]
        public int Winner { get; set; } // automat zrobic   // losowanie druzyn zrobic ?
    }
}
