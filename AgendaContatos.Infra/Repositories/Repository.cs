using AgendaContatos.Domain.Interfaces;
using AgendaContatos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AgendaContatos.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ContatoContext _contatoContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(ContatoContext contatoContext)
        {
            _contatoContext = contatoContext;
            _dbSet = _contatoContext.Set<T>();
        }

        public T Editar(T entity)
        {
            _contatoContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }

        public bool Excluir(int id)
        {
            var entity = ListarPorId(id);

            if (entity != null)
            {
                _contatoContext.Entry(entity).State = EntityState.Deleted;

                return SaveChanges() > 0;
            }
            else
            {
                throw new ArgumentException("Contato não encontrado!");
            }
        }

        public T Incluir(T entity)
        {
            _dbSet.Add(entity);
            SaveChanges();

            return entity;
        }

        public T ListarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public ICollection<T> ListarTodos()
        {
            return _dbSet.ToListAsync<T>().Result;
        }

        private int SaveChanges()
        {
            return _contatoContext.SaveChanges();
        }

        public void Dispose()
        {
            _contatoContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}