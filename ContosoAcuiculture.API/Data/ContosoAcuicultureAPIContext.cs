using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoAcuiculture.API.Models;

    public class ContosoAcuicultureAPIContext : DbContext
    {
        public ContosoAcuicultureAPIContext (DbContextOptions<ContosoAcuicultureAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ContosoAcuiculture.API.Models.ContosoAcuiculture> ContosoAcuiculture { get; set; }
    }
