using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortfolioPanel.Entities
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public DateTime CDate { get; set; } = DateTime.Now;

        [Required]
        public bool Active { get; set; } = true;

        [Required]
        public bool Deleted { get; set; } = false;

        public Nullable<DateTime> UDate { get; set; }
        public Nullable<DateTime> DDate { get; set; }
    }
}