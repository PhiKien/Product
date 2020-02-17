using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using ProductManagement.Common;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;

namespace ProductManagement.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private ProductContext db = new ProductContext();
        private IProductProcRepository _productProcRepository;

        public ProductsController(IProductProcRepository productProcRepository)
        {
            _productProcRepository = productProcRepository;
        }

        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            var products = _productProcRepository.GetAll();
            //var categorys = listCategory();

            //var listProduct = compareList((List<Product>)products, categorys);

            var list = products.OrderBy(p => p.ID);

            return View(list.ToPagedList(page == null ? 1 : page.Value, 5));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productProcRepository.GetById(id);
            product.Category = GetCategory(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(listCategory(), "ID", "Name");
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
                _productProcRepository.Add(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(listCategory(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productProcRepository.GetById(id);

            //Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(listCategory(), "ID", "Name", product.CategoryID);
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
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                _productProcRepository.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(listCategory(), "ID", "Name", product.CategoryID);
            return View(product);
        }


        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productProcRepository.GetById(id);

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
            //Product product = db.Products.Find(id);
            //db.Products.Remove(product);
            //db.SaveChanges();
            _productProcRepository.Delete(id);
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

        //get all category
        private List<Category> listCategory()
        {
            var categorys = db.Database.SqlQuery<Category>(CommonConstantProc.PROC_GET_ALL_CATEGORY).ToList();
            return categorys;
        }

        //get category by id
        private Category getCategoryByID(int id)
        {
            var category = db.Database.SqlQuery<Category>(CommonConstantProc.PROC_GET_CATEGORY_BY_ID, id).Single();
            return category;
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

        private Category GetCategory(int? id)
        {
            return db.Categorys.Single(c => c.ID == id);
        }
    }
}
