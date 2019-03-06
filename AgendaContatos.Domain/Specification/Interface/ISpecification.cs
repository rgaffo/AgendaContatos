namespace AgendaContatos.Domain.Specification.Interface
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        string Propriedade { get; set; }
        string Mensagem { get; set; }

        bool IsSatisfiedBy(TEntity entity);
    }
}