using System;
using System.Collections.Generic;

namespace AgendaContatos.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        ICollection<T> ListarTodos();
        T ListarPorId(int id);
        T Incluir(T entity);
        T Editar(T entity);
        bool Excluir(int id);
    }
}