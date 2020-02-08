using System;
using System.Net;
using System.Web.Mvc;
using ProductManagement.Common;
using ProductManagement.Repository.Interface;
using ProductManagement.ViewModels;

namespace ProductManagement.Controllers
{
    public class UserController : Controller
    {
   
        IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            //var listUser = _userRepository.GetAll();
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(long id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userViewModel = _userRepository.GetById(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,Name,Address,Email,Phone,CreateDate,ModifiedDate,Status,RoleID")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = Encryptor.MD5Hash(userViewModel.Password);               
                
                UserViewModel userViewModel2 = new UserViewModel();
                userViewModel2.UserName = userViewModel.UserName;
                userViewModel2.Name = userViewModel.Name;
                userViewModel2.Password = passwordHash;
                userViewModel2.Email = userViewModel.Email;
                userViewModel2.Address = userViewModel.Address;
                userViewModel2.Phone = "";
                userViewModel2.CreateDate = DateTime.Now;
                userViewModel2.ModifiedDate = DateTime.Now;
                userViewModel2.Status = true;
                userViewModel2.RoleID = 3;

                _userRepository.Add(userViewModel2);
                _userRepository.SaveChange();
                return RedirectToAction("Index", "Login");
            }

            return View(userViewModel);
        }

        // GET: User/Edit/5
        public ActionResult Edit(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _userRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,Name,Address,Email,Phone,CreateDate,ModifiedDate,Status,RoleID")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Update(userViewModel);
                _userRepository.Update(userViewModel);
                _userRepository.SaveChange();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: User/Delete/5
        public ActionResult Delete(long id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userViewModel = _userRepository.GetById(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var userViewModel = _userRepository.GetById(id);
            _userRepository.Delete(userViewModel);
            _userRepository.SaveChange();   
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session[Common.CommonConstant.USER_SESSTION] = null;
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }


    }
}
