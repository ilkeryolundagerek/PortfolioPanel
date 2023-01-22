using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioPanel.Utils
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T Read(object key);
        IEnumerable<T> Read(Expression<Func<T, bool>> expression = null);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object key);
        void Save();
    }
}
