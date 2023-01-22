using PortfolioPanel.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioPanel.Models
{
    public class CategoryListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        private static readonly CategoryRepository repo = new CategoryRepository();
        public static IEnumerable<CategoryListItem> ReadAll()
        {
            return from c in repo.Read()
                   select new CategoryListItem
                   {
                       Id = c.Id,
                       Title = c.Title,
                       Active = c.Active,
                       Deleted= c.Deleted
                   };
        }
    }

}