using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PileOfShame.Models;

namespace PileOfShame.Data
{
    public class PileOfShameContext : DbContext
    {
        public PileOfShameContext (DbContextOptions<PileOfShameContext> options)
            : base(options)
        {
        }

        public DbSet<PileOfShame.Models.GameModel> GameModel { get; set; }
    }
}
