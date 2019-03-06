using AgendaContatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaContatos.Infra.Context.FluentAPIConfig
{
    public class ContatoTypeConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.ContatoId);
            builder.Property(c => c.ContatoNome).HasMaxLength(100);
            builder.Property(c => c.ContatoEmail).HasMaxLength(150);
            builder.Property(c => c.ContatoCelular).HasMaxLength(11);
            builder.Ignore(c => c.ListaErros);
        }
    }
}