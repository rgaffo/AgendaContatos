using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Specification.Interface;

namespace AgendaContatos.Domain.Specification.ContatoSpecification
{
    public class TelefonePreenchidoSpecification : ISpecification<Contato>
    {
        public string Propriedade { get; set; }
        public string Mensagem { get; set; }

        public bool IsSatisfiedBy(Contato entity)
        {
            if (string.IsNullOrEmpty(entity.ContatoCelular))
            {
                Mensagem = "Celular do contato é obrigatório";
                Propriedade = nameof(entity.ContatoCelular);
            }

            return !(string.IsNullOrEmpty(entity.ContatoCelular));
        }
    }
}