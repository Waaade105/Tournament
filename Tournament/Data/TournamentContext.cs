using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Models;

namespace Tournament.Data
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<Scheduler> Schedules { get; set; }


    }
}
