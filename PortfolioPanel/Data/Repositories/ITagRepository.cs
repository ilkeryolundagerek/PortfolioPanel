using PortfolioPanel.Entities;
using PortfolioPanel.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PortfolioPanel.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        IEnumerable<Tag> ReadWithPosts(Expression<Func<Tag, bool>> expression = null);
    }
}
