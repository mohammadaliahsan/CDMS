using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eramake;
using CDMS.BLL;
using CDMS.Models;
using System.Data;
using System.Web.Security;
using System.Web.Mail;
using System.Net.Mail;
//using WebMatrix.WebData;

namespace CDMS.Controllers
{
    public class UsersController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        UsersManager usersManager = new UsersManager();
        DashboardManager aDashboardManager = new DashboardManager();
        BranchManager aBranchManager = new BranchManager();

        [HttpGet]
        public JsonResult IsUserNameExist(Users aUser)
        {
            List<Users> users = usersManager.GetUsers();
            bool isExist = users.FirstOrDefault(a => a.UserName.ToLowerInvariant().Equals(aUser.UserName.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UsersRegister()
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            Users users = new Users();
            return View(users);
        }

        [HttpGet]
        public ActionResult UsersChangePassowrd()
        {
            UsersChangePassowrd usersn = new UsersChangePassowrd();
            return View(usersn);
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            try
            {

                users.Password = eCryptography.Encrypt(users.Password);
                ViewBag.Message = usersManager.Save(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login1(UsersChangePassowrd changepasswordd)
        {
            changepasswordd.Password = eCryptography.Encrypt(changepasswordd.Password);
            ViewBag.Message = usersManager.SaveChangePassword(changepasswordd);
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(Users aUsers)
        {
            try
            {

                var data = usersManager.GetUsers();
                var usersDetails = data.Where(a => a.UserName == aUsers.UserName && eCryptography.Decrypt(a.Password) == aUsers.Password).FirstOrDefault();
                if (usersDetails == null)
                {
                    ViewBag.EMessage = "Wrong User Name or Password";
                    return View("../Users/Login");
                }
                else if (usersDetails.Name == "admin")
                {
                    Session["Id"] = usersDetails.Id;
                    Session["Name"] = usersDetails.Name;
                    Session["CompanyId"] = usersDetails.CompanyId;
                    Session["BranchId"] = usersDetails.BranchId;
                    //ViewBag.Teachers = aDashboardManager.GetTotalTeacher();
                    //ViewBag.Students = aDashboardManager.GetTotalStudent();
                    //ViewBag.Departments = aDashboardManager.GetTotalDepartment();
                    //ViewBag.Rooms = aDashboardManager.GetTotalRoom();
                    //ViewBag.Chart = aDashboardManager.GetCount();
                    //ViewBag.Company = aDashboardManager.GetCompany();
                    //ViewBag.Branch = aDashboardManager.GetBranch();
                    return View("../Dashboard/Dashboard");
                }
                else
                {
                    Session["Id"] = usersDetails.Id;
                    Session["Name"] = usersDetails.Name;
                    Session["CompanyId"] = usersDetails.CompanyId;
                    Session["BranchId"] = usersDetails.BranchId;
                    ViewBag.Company = aCompanyManager.GetAllCompany();
                    ViewBag.Branch = aBranchManager.GetAllBranch();

                    //ViewBag.Departments = aDashboardManager.GetTotalDepartment();
                    //ViewBag.Rooms = aDashboardManager.GetTotalRoom();
                    //ViewBag.Chart = aDashboardManager.GetCount();
                    return View("../Dashboard/Dashboard1");
                }

            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Users");
        }
    }
}