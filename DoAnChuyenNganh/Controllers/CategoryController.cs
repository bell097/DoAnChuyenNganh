
using DoAnChuyenNganh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh.Controllers
{
    public class CategoryController : Controller
    {
        
        ShopModelContext db = new ShopModelContext();
      
        public ActionResult ViewCategory(int Id)
        {

            //var KetQua = (from item in db.SmallCategories
            //              select item).ToList();
            //var KetQua1 = (from item in db.Categories
            //               select item).ToList();

            //return View(db.SmallCategories.ToList());
            //var listSmall = (from sp in db.Products
            //                 join sm in db.SmallCategories
            //                 on sp.smallcategory_id equals sm.smallcategory_id
            //                 select sm).Distinct().ToList();
            var listProductCa = db.Products.Where(n => n.SmallCategory.Category.category_id == Id).ToList();
            return View(listProductCa);
        }


        public ActionResult ProductCategory(int Id)
        {
            var listProduct = db.Products.Where(n => n.smallcategory_id == Id).ToList();
            return View(listProduct); 
        }

    }
}