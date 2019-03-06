using AgendaContatos.Domain.Specification.ContatoSpecification;
using AgendaContatos.Domain.Specification.Interface;
using System;
using System.Collections.Generic;

namespace AgendaContatos.Domain.Entities
{
    public class Contato
    {
        private ICollection<ISpecification<Contato>> _regrasNegocio;

        public Contato()
        {
            _regrasNegocio = new List<ISpecification<Contato>>()
            {
                new NomePreenchidoSpecification(),
                new TelefonePreenchidoSpecification()
            };

            ListaErros = new Dictionary<string, string>();
        }

        public int ContatoId { get; set; }
        public string ContatoNome { get; set; }
        public string ContatoEmail { get; set; }
        public string ContatoCelular { get; set; }
        public DateTime ContatoDataCriacao { get; set; }
        public DateTime ContatoDataAlteracao { get; set; }
        public Dictionary<string, string> ListaErros { get; set; }

        public bool ContatoValido()
        {
            foreach (var regra in _regrasNegocio)
            {
                if (!regra.IsSatisfiedBy(this))
                    ListaErros.Add(regra.Propriedade, regra.Mensagem);
            }

            return ListaErros.Count == 0;
        }
    }
}