using Microsoft.EntityFrameworkCore;
using NotificacaoColetaApi.Models;

namespace NotificacaoColetaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coleta> Coletas { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coleta>().ToTable("Coleta");

            modelBuilder.Entity<Notificacao>().ToTable("Notificacao");
        }
    }
}