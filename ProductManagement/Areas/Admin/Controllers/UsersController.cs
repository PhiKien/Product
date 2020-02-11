using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Common;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.ViewModels;

namespace ProductManagement.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private ProductContext db = new ProductContext();
        private IUserProcRepository _userProcRepository;

        public UsersController(IUserProcRepository userProcRepository)
        {
            _userProcRepository = userProcRepository;
        }



        // GET: Admin/Users
        public ActionResult Index()
        {
            //var list = db.Users.Include(u => u.Role).ToList();
            var listUser = compareList((List<User>)_userProcRepository.GetAll(), roles());
            return View(listUser);
        }        

        // GET: Admin/Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userProcRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,Name,Address,Email,Phone,CreateDate,ModifiedDate,Status,RoleID")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var users = _userProcRepository.GetAll().FirstOrDefault(u => u.UserName == userViewModel.UserName);
                if (users == null)
                {
                    var passwordHash = Encryptor.MD5Hash(userViewModel.Password);

                    UserViewModel userViewModel2 = new UserViewModel();
                    userViewModel2.UserName = userViewModel.UserName;
                    userViewModel2.Name = userViewModel.Name;
                    userViewModel2.Password = passwordHash;
                    userViewModel2.Email = userViewModel.Email;
                    userViewModel2.Address = userViewModel.Address;
                    userViewModel2.Phone = userViewModel.Phone;
                    userViewModel2.CreateDate = DateTime.Now;
                    userViewModel2.ModifiedDate = DateTime.Now;
                    userViewModel2.Status = userViewModel.Status;
                    userViewModel2.RoleID = userViewModel.RoleID;

                    _userProcRepository.Add(userViewModel2);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "This account has already existed!");
                }
            }

            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", userViewModel.RoleID);
            return View(userViewModel);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userProcRepository.GetById(id);
            //User user2 = new User(user.UserName, user.Password, user.Name, user.Address, user.Email, user.Phone, user.CreateDate, user.Status, user.RoleID);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,Name,Address,Email,Phone,CreateDate,ModifiedDate,Status,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                _userProcRepository.Update(user);
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userProcRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _userProcRepository.Delete(id);
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

        public ActionResult Logout()
        {
            Session[Common.CommonConstant.USER_SESSTION] = null;
            Session.Clear();
            return RedirectToAction("Index", "../Login");
        }

        private List<Role> roles()
        {
            var listRole = db.Roles.ToList();
            return listRole;
        }

        private List<User> compareList(List<User> users, List<Role> roles)
        {
            foreach (var item in roles)
            {
                foreach (var item2 in users)
                {
                    if (item.ID == item2.RoleID)
                    {
                        item2.Role = item;
                    }
                }
            }
            return users;
        }
    }
}
