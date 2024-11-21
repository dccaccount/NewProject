using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class HomeController : Controller
    {
        DBContextEntity dbContext;

        public HomeController()
        {
            dbContext = new DBContextEntity();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserDetails(List<ProfileModel> user)
        {
            DataTable dt = dbContext.Insert_User_Details(user);

            if (dt.Rows.Count > 0)
            {
                ViewBag.Message = "Data Insertion success";
            }
            return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UserEmailValidate(string email)
        {
            object result = dbContext.User_email_validate(email);

           
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UserLoginValidate(List<ProfileModel> user)
        {
            DataTable dt=null;
            var result = "";
            try
            {
                foreach (var res in user)
                {
                    dt = dbContext.Validte_User_Login(res.Email, res.Name);
                }

                if (dt.Rows.Count > 0 && dt != null)
                {
                    result = dt.Rows[0][0].ToString();
                    Session["luid"] = result;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DashBoard()
        {
            return View();
        }

    }
}