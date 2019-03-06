using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces;
using AgendaContatos.Infra.Context;

namespace AgendaContatos.Infra.Repositories
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(ContatoContext contatoContext) : base(contatoContext)
        {

        }
    }
}