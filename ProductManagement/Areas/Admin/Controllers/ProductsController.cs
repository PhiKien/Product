using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProductManagement.Common;
using ProductManagement.Models;

namespace ProductManagement.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private ProductContext db = new ProductContext();

        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            var listProduct = compareList(listProducts(null), listCategorys(null));

            var list = listProduct.OrderBy(p => p.ID);
            
            return View(list.ToPagedList(page == null ? 1 : page.Value, 5));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var products = listProducts(id);

            Product product = products.Single(p => p.ID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categorys, "ID", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,NumberInStock,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categorys, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryID = new SelectList(db.Categorys, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,NumberInStock,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categorys, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

        //get list category
        private List<Category> listCategorys(int? id)
        {
            if (id == null)
            {
                var listCategory = db.Database.SqlQuery<Category>(CommonConstantProc.PROC_GET_ALL_CATEGORY).ToList();
                return listCategory;
            }
            else
            {
                var listCategory = db.Database.SqlQuery<Category>(CommonConstantProc.PROC_GET_CATEGORY_BY_ID, id).ToList();
                return listCategory;
            }
        }

        //get list product
        private List<Product> listProducts(int? id)
        {
            if (id == null)
            {
                var listProduct = db.Database.SqlQuery<Product>(CommonConstantProc.PROC_GET_ALL_PRODUCT).ToList();
                return listProduct;
            }
            else
            {
                var listProduct = db.Database.SqlQuery<Product>(CommonConstantProc.PROC_GET_PRODUCT_BY_ID, new SqlParameter("@productID", id)).ToList();
                return listProduct;
            }
        }

        //compare and assign
        private List<Product> compareList(List<Product> products, List<Category> categories)
        {
            foreach (var item in categories)
            {
                foreach (var item2 in products)
                {
                    if (item.ID == item2.CategoryID)
                    {
                        item2.Category = item;
                    }
                }
            }
            return products;
        }
    }
}
