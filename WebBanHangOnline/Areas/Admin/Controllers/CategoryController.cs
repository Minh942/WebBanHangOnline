using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = dbContext.Categories;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.ChuyenCoDauThanhKhongDau(model.Title);
                dbContext.Categories.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = dbContext.Categories.Find(id);
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.ChuyenCoDauThanhKhongDau(model.Title);
                dbContext.Entry(model).Property(x => x.Title).IsModified = true;
                dbContext.Entry(model).Property(x => x.Descreption).IsModified = true;
                dbContext.Entry(model).Property(x => x.Alias).IsModified = true;
                dbContext.Entry(model).Property(x => x.SeoDesception).IsModified = true;
                dbContext.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                dbContext.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                dbContext.Entry(model).Property(x => x.Position).IsModified = true;           
                dbContext.Entry(model).Property(x => x.ModifiedDate).IsModified = true;           
                dbContext.Entry(model).Property(x => x.ModifiedBy).IsModified = true;           
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbContext.Categories.Find(id);
            if(item != null)
            {                
                dbContext.Categories.Remove(item);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}