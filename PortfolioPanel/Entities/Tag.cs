using System.Collections.Generic;

namespace PortfolioPanel.Entities
{
    public class Tag : Base
    {
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}