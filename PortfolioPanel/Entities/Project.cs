using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioPanel.Entities
{
    public class Project : PublishBase
    {
        public Nullable<DateTime> Start { get; set; }
        public Nullable<DateTime> End { get; set; }
        [Required]
        public string Status { get; set; } = "Completed";
        public string Owner { get; set; }
        public virtual ICollection<TeamMember> Team { get; set; }
        public string GithubUrl { get; set; }
    }
}