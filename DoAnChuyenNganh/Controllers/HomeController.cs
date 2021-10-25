using DoAnChuyenNganh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DoAnChuyenNganh.Controllers
{
    
    public class HomeController : Controller
    {
        ShopModelContext db = new ShopModelContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            var dscategory = db.Categories.ToList();
            ViewBag.category = dscategory;

            var dssmallcategory = db.SmallCategories.ToList();
            ViewBag.smallcategory = dssmallcategory; 
            return PartialView("_MenuCategory");
        }
        public ActionResult RenderFooter()
        {
            var dscategory = db.Categories.ToList();
            ViewBag.category = dscategory;

            var dssmallcategory = db.SmallCategories.ToList();
            ViewBag.smallcategory = dssmallcategory;
            return PartialView("_Footer");
        }
        public ActionResult HotproductTPCN()
        {
            IQueryable<Product> list = (from p in db.Products
                                        where p.SmallCategory.category_id == 1
                                        orderby p.product_id
                                        select p).Take(6);
            return PartialView("_HotproductTPCN", list);
        }
        public ActionResult HotproductDMP()
        {
            IQueryable<Product> list1 = (from p in db.Products
                                        where p.SmallCategory.category_id == 2
                                        orderby p.product_id
                                        select p).Take(6);
            return PartialView("_HotproductDMP", list1);
        }
        public ActionResult HotproductCSCN()
        {
            IQueryable<Product> list1 = (from p in db.Products
                                         where p.SmallCategory.category_id == 3
                                         orderby p.product_id
                                         select p).Take(6);
            return PartialView("_HotproductCSCN", list1);
        }
        public ActionResult HotproductTBYT()
        {
            IQueryable<Product> list1 = (from p in db.Products
                                         where p.SmallCategory.category_id == 4
                                         orderby p.product_id
                                         select p).Take(6);
            return PartialView("_HotproductTBYT", list1);
        }
        public ActionResult HotproductT()
        {
            IQueryable<Product> list1 = (from p in db.Products
                                         where p.SmallCategory.category_id == 5
                                         orderby p.product_id
                                         select p).Take(6);
            return PartialView("_HotproductT", list1);
        }

    }
}