using PagedList;
using ProductManagement.Common;
using ProductManagement.Repository.Interface;
using ProductManagement.ViewModels;
using System.Net;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : BaseController
    {
        private IProductRepository _productRepository;
       
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductController()
        {
        }

        // GET: Product
        //[CheckAuthority(RoleID = 1)]
        public ActionResult Index(int? page)
        {
            var session = (UserLogin) Session[CommonConstant.USER_SESSTION];
            var listProduct = _productRepository.GetByRoleID(session.RoleID);
            return View(listProduct.ToPagedList(page == null ? 1 : page.Value, 3));
        }

        [HttpGet]
        //[CheckAuthority(RoleID = 1)]
        public ActionResult FindProductByCategoryID(int? page, int? id)
        {
            var listAll = _productRepository.GetByCondition(id);
            return Json(listAll.ToPagedList(page == null ? 1 : page.Value, 3), JsonRequestBehavior.AllowGet);
        }

        // GET: Product/Details/5
        [CheckAuthority(RoleID = 1)]
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _productRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Product/Create
        [CheckAuthority(RoleID = 1)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckAuthority(RoleID = 1)]
        public ActionResult Create([Bind(Include = "Name, Description, NumberInStock, CategoryID")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(productViewModel);
                _productRepository.SaveChange();
                return RedirectToAction("Index");
            }

            return View(productViewModel);
        }

        // GET: Product/Edit/5
        [CheckAuthority(RoleID = 1)]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _productRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckAuthority(RoleID = 1)]
        public ActionResult Edit([Bind(Include = "ID, Name, Description, NumberInStock, CategoryID")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(productViewModel);
                _productRepository.SaveChange();
                return RedirectToAction("Index");
            }
            return View(productViewModel);
        }

        // GET: Product/Delete/5
        [CheckAuthority(RoleID = 1)]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _productRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CheckAuthority(RoleID = 1)]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = _productRepository.GetById(id);
            _productRepository.Delete(model);
            _productRepository.SaveChange();
            return RedirectToAction("Index");
        }
    }
}
