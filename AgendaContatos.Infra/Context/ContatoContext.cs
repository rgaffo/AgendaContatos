using AgendaContatos.Domain.Entities;
using AgendaContatos.Infra.Context.FluentAPIConfig;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Infra.Context
{
    public class ContatoContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public ContatoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoTypeConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}