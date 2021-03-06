﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.DTOs
{
    public class TeamCreateUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Coach { get; set; }
        [Required]
        [MaxLength(25)]
        public string State { get; set; }
    }
}
