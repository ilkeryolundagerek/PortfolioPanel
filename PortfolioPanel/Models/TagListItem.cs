using PortfolioPanel.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioPanel.Models
{
    public class TagListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        private static readonly TagRepository repo = new TagRepository();
        public static IEnumerable<TagListItem> ReadAll()
        {
            return from c in repo.Read()
                   select new TagListItem
                   {
                       Id = c.Id,
                       Title = c.Title,
                       Active= c.Active,
                       Deleted= c.Deleted
                   };
        }
    }

}