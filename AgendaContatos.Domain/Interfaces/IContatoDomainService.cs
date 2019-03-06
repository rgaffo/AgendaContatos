using AgendaContatos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AgendaContatos.Domain.Interfaces
{
    public interface IContatoDomainService : IDisposable
    {
        ICollection<Contato> ListarTodos();
        Contato ListarPorId(int id);
        Contato IncluirContato(Contato contato);
        Contato EditarContato(Contato contato);
        bool ExcluirContato(int id);
    }
}