using Hiking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Data
{
    public class HikingContext : DbContext
    {
        public HikingContext(DbContextOptions<HikingContext> options) : base(options)
        {
        }

        protected HikingContext()
        {
        }

        //Properties
        public DbSet<Hike> Hikes { get; set; }
    }
}
