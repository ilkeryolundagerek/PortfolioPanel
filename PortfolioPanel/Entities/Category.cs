using System.Collections.Generic;

namespace PortfolioPanel.Entities
{
    public class Category : Base
    {
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}