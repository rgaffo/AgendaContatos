using AgendaContatos.AppService.Interfaces;
using AgendaContatos.AppService.Models;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace AgendaContatos.AppService.Service
{
    public class ContatoAppService : IContatoAppService
    {
        private IContatoDomainService _contatoDomainService;

        public ContatoAppService(IContatoDomainService contatoDomainService)
        {
            _contatoDomainService = contatoDomainService;
        }

        public Contato ModelToDomain(ContatoModel entityModel)
        {
            var contato = new Contato();

            if (entityModel != null)
            {
                contato.ContatoId = entityModel.ContatoId;
                contato.ContatoNome = entityModel.ContatoNome;
                contato.ContatoEmail = entityModel.ContatoEmail;
                contato.ContatoCelular = entityModel.ContatoCelular;
            }

            return contato;
        }

        public ContatoModel DomainToModel(Contato entityDomain)
        {
            var contato = new ContatoModel();

            if (entityDomain != null)
            {
                contato.ContatoId = entityDomain.ContatoId;
                contato.ContatoNome = entityDomain.ContatoNome;
                contato.ContatoEmail = entityDomain.ContatoEmail;
                contato.ContatoCelular = entityDomain.ContatoCelular;
                contato.ListaErros = entityDomain.ListaErros;
            }

            return contato;
        }

        public ContatoModel Editar(ContatoModel entityModel)
        {
            var contato = ModelToDomain(entityModel);
            return DomainToModel(_contatoDomainService.EditarContato(contato));
        }

        public bool Excluir(int id)
        {
            return _contatoDomainService.ExcluirContato(id);
        }

        public ContatoModel Incluir(ContatoModel entityModel)
        {
            var contato = ModelToDomain(entityModel);
            return DomainToModel(_contatoDomainService.IncluirContato(contato));
        }

        public ContatoModel ListarPorId(int id)
        {
            return DomainToModel(_contatoDomainService.ListarPorId(id));
        }

        public ICollection<ContatoModel> ListarTodos()
        {
            var domainList = _contatoDomainService.ListarTodos();
            var modelList = new List<ContatoModel>();

            foreach (var item in domainList)
            {
                modelList.Add(DomainToModel(item));
            }

            return modelList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}