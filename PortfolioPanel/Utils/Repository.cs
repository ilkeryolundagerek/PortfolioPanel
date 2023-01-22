using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PortfolioPanel.Utils
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _set.Add(entity);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void Delete(object key)
        {
            var entity = Read(key);
            Delete(entity);
        }

        public T Read(object key)
        {
            return _set.Find(key);
        }

        public IEnumerable<T> Read(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? _set.Where(expression) : _set;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
