using System.Collections.Generic;

namespace PortfolioPanel.Entities
{
    public class TeamMember : Base
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}