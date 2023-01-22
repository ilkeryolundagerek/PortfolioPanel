using PortfolioPanel.Entities;
using PortfolioPanel.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PortfolioPanel.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository() : base(new PortfolioContext()) { }

        public IEnumerable<Post> ReadByCategory(string categoryName, Expression<Func<Post, bool>> expression = null)
        {
            return ReadWithCategoryAndTag(expression).Where(x => x.Categories.Any(y => y.Title == categoryName));
        }

        public IEnumerable<Post> ReadByTag(string tagName, Expression<Func<Post, bool>> expression = null)
        {
            return ReadWithCategoryAndTag(expression).Where(x => x.Tags.Any(y => y.Title == tagName));
        }

        public IEnumerable<Post> ReadWithCategoryAndTag(Expression<Func<Post, bool>> expression = null)
        {
            var data = _set.Include(c => c.Categories).Include(t => t.Tags);
            return expression != null ? data.Where(expression) : data;
        }
    }
}
