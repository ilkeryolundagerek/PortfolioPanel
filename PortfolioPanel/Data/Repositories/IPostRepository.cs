using PortfolioPanel.Entities;
using PortfolioPanel.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PortfolioPanel.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> ReadWithCategoryAndTag(Expression<Func<Post, bool>> expression = null);
        IEnumerable<Post> ReadByCategory(string categoryName, Expression<Func<Post, bool>> expression = null);
        IEnumerable<Post> ReadByTag(string tagName, Expression<Func<Post, bool>> expression = null);
    }
}
