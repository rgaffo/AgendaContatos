using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Specification.Interface;

namespace AgendaContatos.Domain.Specification.ContatoSpecification
{
    public class NomePreenchidoSpecification : ISpecification<Contato>
    {
        public string Propriedade { get; set; }
        public string Mensagem { get; set; }

        public bool IsSatisfiedBy(Contato entity)
        {
            if (string.IsNullOrEmpty(entity.ContatoNome))
            {
                Mensagem = "Nome do contato é obrigatório";
                Propriedade = nameof(entity.ContatoNome);
            }

            return !(string.IsNullOrEmpty(entity.ContatoNome));
        }
    }
}