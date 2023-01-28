using PortfolioPanel.Entities;
using PortfolioPanel.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PortfolioPanel.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository() : base(new PortfolioContext())
        {
        }
        public CategoryRepository(PortfolioContext context) : base(context) { }

        public IEnumerable<Category> ReadWithPosts(Expression<Func<Category, bool>> expression = null)
        {
            var data = _set.Include(p => p.Posts);
            return expression != null ? data.Where(expression) : data;
        }
    }
}
