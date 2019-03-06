using AgendaContatos.AppService.Models;
using AgendaContatos.Domain.Entities;

namespace AgendaContatos.AppService.Interfaces
{
    public interface IContatoAppService : IAppService<Contato, ContatoModel>
    {

    }
}