using PortfolioPanel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioPanel.Models
{
    public class BlogListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public Nullable<DateTime> PDate { get; set; }
        public bool IsDraft { get; set; } = true;
        public string FeaturedImage { get; set; }
        public IEnumerable<CategoryListItem> Categories { get; set; }
        public IEnumerable<TagListItem> Tags { get; set; }

        private static PostRepository repo = new PostRepository();
        public static IEnumerable<BlogListItem> ReadAll()
        {
            return from p in repo.Read()
                   select new BlogListItem
                   {
                       Id = p.Id,
                       Title = p.Title,
                       Active = p.Active,
                       Deleted = p.Deleted,
                       IsDraft = p.IsDraft,
                       FeaturedImage = p.FeaturedImage,
                       PDate = p.PDate,
                       Categories = p.Categories.Select(x => new CategoryListItem { Id = x.Id, Title = x.Title }),
                       Tags = p.Tags.Select(x => new TagListItem { Id = x.Id, Title = x.Title })
                   };
        }
    }


}