using System;
using System.Collections.Generic;

namespace AgendaContatos.AppService.Interfaces
{
    public interface IAppService<TDomain, TModel> : IDisposable where TDomain : class where TModel : class
    {
        TDomain ModelToDomain(TModel entityModel);
        TModel DomainToModel(TDomain entityDomain);

        ICollection<TModel> ListarTodos();
        TModel ListarPorId(int id);
        TModel Incluir(TModel entityModel);
        TModel Editar(TModel entityModel);
        bool Excluir(int id);
    }
}