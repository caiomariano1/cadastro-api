using cadastro_api.Data.Map;
using cadastro_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastro_api.Data
{
    public class SistemaContatosDbContext : DbContext
    {
        public SistemaContatosDbContext(DbContextOptions<SistemaContatosDbContext> options) : base(options) 
        { 
        }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
