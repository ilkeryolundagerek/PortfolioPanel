using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortfolioPanel.Entities
{
    public abstract class PublishBase:Base
    {
        public Nullable<DateTime> PDate { get; set; }

        [Required]
        public bool IsDraft { get; set; } = true;

        [Required]
        public string HtmlContent { get; set; }

        [Required]
        public string FeaturedImage { get; set; } = "/assets/img/no-image.jpg";

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}