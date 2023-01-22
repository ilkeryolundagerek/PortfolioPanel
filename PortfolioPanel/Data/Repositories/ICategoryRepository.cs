using PortfolioPanel.Entities;
using PortfolioPanel.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioPanel.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> ReadWithPosts(Expression<Func<Category, bool>> expression = null);
    }
}
