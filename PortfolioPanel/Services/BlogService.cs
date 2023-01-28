﻿using PortfolioPanel.Data;
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
        private static readonly PortfolioContext _context = new PortfolioContext();
        public static void CreatePost(BlogCreateAndEditModel post)
        {
            PostRepository postRepo = new PostRepository(_context);
            CategoryRepository categoryRepo = new CategoryRepository(_context);
            TagRepository tagRepo = new TagRepository(_context);
            var cids = post.Categories.Select(x => x.Id);
            var tids = post.Tags.Select(x => x.Id);
            var entity = new Post
            {
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                HtmlContent = post.HtmlContent,
                FeaturedImage = post.FeaturedImage,
                Categories = categoryRepo.Read(x => cids.Contains(x.Id)).ToList(),
                Tags = tagRepo.Read(x => tids.Contains(x.Id)).ToList(),
                IsDraft = post.IsDraft,
                PDate = post.PDate
            };
            postRepo.Create(entity);
            postRepo.Save();
        }
    }
}