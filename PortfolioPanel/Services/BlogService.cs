using PortfolioPanel.Data.Repositories;
using PortfolioPanel.Entities;
using PortfolioPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioPanel.Services
{
    public static class BlogService
    {
        private static PostRepository postRepo = new PostRepository();

        public static void CreatePost(BlogCreateAndEditModel post)
        {
            var entity = new Post
            {
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                HtmlContent = post.HtmlContent,
                FeaturedImage = post.FeaturedImage,
                Categories = post.Categories.Select(c => new Category { Id = c.Id, Title = c.Title }).ToList(),
                Tags = post.Tags.Select(c => new Tag { Id = c.Id, Title = c.Title }).ToList(),
                IsDraft = post.IsDraft,
                PDate = post.PDate
            };
            postRepo.Create(entity);
            postRepo.Save();
        }
    }
}