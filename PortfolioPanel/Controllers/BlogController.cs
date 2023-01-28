using PortfolioPanel.Models;
using PortfolioPanel.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioPanel.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View(new BlogIndexViewModel());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewData["Categories"] = CategoryListItem.ReadAll();
            ViewData["Tags"] = TagListItem.ReadAll();
            return View(new BlogCreateAndEditModel());
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(BlogCreateAndEditModel model, HttpPostedFileBase FeaturedImage, int[] Categories, int[] Tags)
        {
            if (FeaturedImage != null)
            {
                if (FeaturedImage.ContentLength > 0)
                {
                    string fName = DateTime.Now.ToString("MMddyyyy_HHmmss_fffffff") + Path.GetExtension(FeaturedImage.FileName);
                    string fPath = "/content/uploads/" + fName;
                    FeaturedImage.SaveAs(Server.MapPath(fPath));
                    model.FeaturedImage = fPath;
                }
            }

            if (Categories.Length > 0)
            {
                var c = CategoryListItem.ReadAll().Where(x => Categories.Contains(x.Id)).ToList();
                model.Categories = c;
            }

            if (Tags.Length > 0)
            {
                var t = TagListItem.ReadAll().Where(x => Tags.Contains(x.Id)).ToList();
                model.Tags = t;
            }
            ModelState.Remove("Categories");
            ModelState.Remove("Tags");
            if (ModelState.IsValid)
            {
                BlogService.CreatePost(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categories"] = CategoryListItem.ReadAll();
            ViewData["Tags"] = TagListItem.ReadAll();
            return View(model);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
