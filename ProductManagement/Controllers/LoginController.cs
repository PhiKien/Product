using ProductManagement.Common;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class LoginController : Controller
    {
        IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = _userRepository.Login(loginModel.UserName, loginModel.PassWord);
                if (result == 1)
                {
                    var user = _userRepository.GetById(loginModel.UserName);
                    var userSesstion = new UserLogin();
                    userSesstion.UserID = user.ID;
                    userSesstion.UserName = user.UserName;                    
                    userSesstion.RoleID = user.RoleID;
                    var listRole = _userRepository.GetListRoleId(loginModel.UserName);
                    Session.Add(CommonConstant.SESSION_CREDENTIALS, listRole);
                    Session.Add(CommonConstant.USER_SESSTION, userSesstion);
                    return RedirectToAction("Index", "Product");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "User account or password is incorrect!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "The account is locked!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "User account or password is incorrect!");
                }
                else
                {
                    ModelState.AddModelError("", "Login fail!");
                }
            }
            return View("Index");
        }

        
    }
}