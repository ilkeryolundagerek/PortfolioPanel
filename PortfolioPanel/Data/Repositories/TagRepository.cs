using PortfolioPanel.Entities;
using PortfolioPanel.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PortfolioPanel.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository() : base(PortfolioContext.Instance())
        {
        }
        public TagRepository(PortfolioContext context) : base(context) { }

        public IEnumerable<Tag> ReadWithPosts(Expression<Func<Tag, bool>> expression = null)
        {
            var data = _set.Include(p => p.Posts);
            return expression != null ? data.Where(expression) : data;
        }
    }
}
