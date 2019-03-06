using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaContatos.Domain.Service
{
    public class ContatoDomainService : IContatoDomainService
    {
        private IContatoRepository _contatoRepository;

        public ContatoDomainService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public Contato EditarContato(Contato contato)
        {
            if (contato.ContatoValido())
            {
                contato.ContatoDataAlteracao = DateTime.UtcNow;
                return _contatoRepository.Editar(contato);
            }

            return contato;
        }

        public bool ExcluirContato(int id)
        {
            return _contatoRepository.Excluir(id);
        }

        public Contato IncluirContato(Contato contato)
        {
            if (contato.ContatoValido())
            {
                contato.ContatoDataCriacao = DateTime.UtcNow;
                return _contatoRepository.Incluir(contato);
            }

            return contato;
        }

        public Contato ListarPorId(int id)
        {
            return _contatoRepository.ListarPorId(id);
        }

        public ICollection<Contato> ListarTodos()
        {
            return _contatoRepository.ListarTodos().OrderBy(c => c.ContatoNome).ToList();
        }

        public void Dispose()
        {
            _contatoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
