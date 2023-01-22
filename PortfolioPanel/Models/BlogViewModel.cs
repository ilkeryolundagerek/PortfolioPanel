using PortfolioPanel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortfolioPanel.Models
{
    //For Index Action
    public class BlogIndexViewModel
    {
        public string ViewTitle { get; set; }
        public IEnumerable<BlogListItem> Posts { get; set; }
        public BlogIndexViewModel()
        {
            Posts = BlogListItem.ReadAll();
            ViewTitle = "All Posts";
        }
    }

    public class CategoryIndexViewModel
    {
        public string ViewTitle { get; set; }
        public IEnumerable<CategoryListItem> Categories { get; set; }
        public CategoryIndexViewModel()
        {
            Categories = CategoryListItem.ReadAll();
            ViewTitle = "All Categories";
        }
    }

    public class TagIndexViewModel
    {
        public string ViewTitle { get; set; }
        public IEnumerable<TagListItem> Tags { get; set; }
        public TagIndexViewModel()
        {
            Tags = TagListItem.ReadAll();
            ViewTitle = "All Tags";
        }
    }
    //For Create & Edit Actions
    public class BlogCreateAndEditModel
    {
        public string ViewTitle { get; set; }
        public int Id { get; set; }

        [Required,Display(Name ="Post Title"),MinLength(5),MaxLength(150)]
        public string Title { get; set; }

        [Required, Display(Name = "Post Short Description"), MinLength(5), MaxLength(500), DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "Publish Date"),DataType(DataType.Date)]
        public Nullable<DateTime> PDate { get; set; }

        [Required, Display(Name = "Post Is Draft?")]
        public bool IsDraft { get; set; } = true;

        [Required, Display(Name = "Html Content"),DataType(DataType.MultilineText)]
        public string HtmlContent { get; set; }

        [Required, Display(Name = "Featured Image"),DataType(DataType.ImageUrl)]
        public string FeaturedImage { get; set; } = "/assets/img/no-image.jpg";

        [Required, Display(Name = "Category")]
        public IEnumerable<CategoryListItem> Categories { get; set; }

        [Required, Display(Name = "Tag")]
        public IEnumerable<TagListItem> Tags { get; set; }

        public BlogCreateAndEditModel()
        {
            ViewTitle = "Create New Post";
        }
    }
}