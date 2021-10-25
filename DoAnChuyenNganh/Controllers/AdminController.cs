using DoAnChuyenNganh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ShopModelContext db = new ShopModelContext();

        // GET: Products
        //[Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            //var products = db.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Origin);
            var products = db.Products.ToList();
            return View(products.ToList());
        }
       

        public ActionResult GetProductById(int id)
        {
            var img = (from a in db.Products

                       where a.category_id == id
                       select a).ToList();
            return View(img);
        }
        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name");
            ViewBag.smallcategory_id = new SelectList(db.SmallCategories, "smallcategory_id", "smallcategory_name");
            ViewBag.origin_id = new SelectList(db.Origins, "origin_id", "origin_name");
            


            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            //lưu tên file
            var fileName = Path.GetFileName(file.FileName);
            //lưu dường dẫn
            var path = Path.Combine(Server.MapPath("~/Assets/images/"), fileName);
            file.SaveAs(path);

            //luu vao db
            product.product_image = fileName;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", product.brand_id);
            ViewBag.smallcategory_id = new SelectList(db.SmallCategories, "smallcategory_id", "smallcategory_name", product.smallcategory_id);
            ViewBag.origin_id = new SelectList(db.Origins, "origin_id", "origin_name", product.origin_id);           
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", product.brand_id);
            ViewBag.smallcategory_id = new SelectList(db.SmallCategories, "smallcategory_id", "smallcategory_name", product.smallcategory_id);
            ViewBag.origin_id = new SelectList(db.Origins, "origin_id", "origin_name", product.origin_id);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,brand_id,origin_id,smallcategory_id,product_image,product_packing,product_format,product_user,product_uses,product_treatment,product_number,product_warning,product_description,prescription_drugs,product_imprice,product_saleprice,product_status,product_quantity")] Product product)
        //public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", product.brand_id);
            ViewBag.smallcategory_id = new SelectList(db.SmallCategories, "smallcategory_id", "smallcategory_name", product.smallcategory_id);
            ViewBag.origin_id = new SelectList(db.Origins, "origin_id", "origin_name", product.origin_id);

            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}