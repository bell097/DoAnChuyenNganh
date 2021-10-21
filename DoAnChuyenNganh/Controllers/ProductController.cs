using System.Data.Linq;
using System.Data.Linq.Mapping;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnChuyenNganh.Models;
//using DoAnChuyenNganh.Dao;

namespace DoAnChuyenNganh.Controllers
{
    public class ProductController : Controller
    {
        // GET: Shop
        DataQuayThuocDataContext db = new DataQuayThuocDataContext();
        public ActionResult ViewProduct(string SearchString, string currentFilter, int? page)
        {
            var listProduct = new List<Product>();
            if(SearchString != null)
            {
                page = 1;
            }    
            else
            {
                SearchString = currentFilter;
            }    
            if(!string.IsNullOrEmpty(SearchString))
            {
                listProduct = db.Products.Where(n => n.product_name.Contains(SearchString)).ToList();
            }    
            else
            {
                listProduct = db.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            listProduct = listProduct.OrderByDescending(n => n.product_id).ToList();
            return View(listProduct.ToPagedList(pageNumber, pageSize));




            ////var dao = new ProductDao();
            ////var model = dao.ListAllPaging(page, pageSize);
            //var KetQua = (from item in db.Products
            //              select item).ToList();

            //return View(db.Products.ToList());

            //var listProduct = db.Products.Where(n => n.product_name.Contains(SearchString)).ToList();
            //return View(listProduct);
        }

        //public ActionResult CategoryProduct()
        //{
        //    var ProductCategory = db.Products.Where(p => p.SmallCategory.smal)
        //}
        // GET: Shop/Details/5
        public ActionResult DetailsProduct(string id)
        {
            var product = from p in db.Products
                          where p.product_id == id
                          select p;
           

            return View(product);
        }




        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
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

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
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
