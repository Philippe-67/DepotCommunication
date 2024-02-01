using ApiRdv.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRdv.Data
{
    
        
    public class RendezVousDbContext : DbContext
        {
            public DbSet<RendezVous> RendezVous { get; set; }

            public RendezVousDbContext(DbContextOptions<RendezVousDbContext> options) : base(options)
            {
            
            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       
    }
}

