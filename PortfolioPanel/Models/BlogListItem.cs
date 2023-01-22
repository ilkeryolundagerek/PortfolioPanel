using System;
using System.Collections.Generic;

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
    }

}