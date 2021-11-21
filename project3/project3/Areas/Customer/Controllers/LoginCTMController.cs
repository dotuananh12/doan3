using project3.App_Service;
using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace project3.Areas.Customer.Controllers
{
    public class LoginCTMController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Json(new ApiResult()
                {
                    success = false,
                    message = "email hoặc mật khẩu không để trống ",
                    data = null,
                    action = null,
                }, JsonRequestBehavior.AllowGet);
            }
            if (db.AdminCPs.Count(x => x.email == email && x.password == password) <= 0)
            {
                return Json(new ApiResult()
                {
                    success = false,
                    message = "email hoặc mật khẩu không chinh xac",
                    data = null,
                    action = null
                }, JsonRequestBehavior.AllowGet);
            }
            if (db.AdminCPs.Count(x => x.email == email ) <= 0)
            {
                return Json(new ApiResult()
                {
                    success = false,
                    message = "email or mat khau khong dung",
                    data = null,
                    action = null
                }, JsonRequestBehavior.AllowGet);
            }
            //lay du lieu
            var use = db.AdminCPs.Where(x => x.email == email)/*.OrderBy(x => x.visa)*/.Take(1).Select(x => new { x.id, x.code, x.email });
            if (use.Count() <= 0)
            {
                return Json(new ApiResult()
                {
                    success = false,
                    message = "khong tim thay nguoi dung",
                    action = null,
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            //Session["AdminCp"] = use;

            FormsAuthentication.SetAuthCookie(use.SingleOrDefault().code, false);
            return Json(new ApiResult()
            {

                success = true,
                message = "Đăng nhập thành công.",
                data = use.SingleOrDefault(),
                action = Url.Action("index", "thongtin")//trang chu
                //action = "/AdminCp/home/index",
            }, JsonRequestBehavior.AllowGet);
        }
    }
}