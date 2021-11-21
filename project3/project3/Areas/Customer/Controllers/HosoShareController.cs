using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Customer.Controllers
{
    public class HosoShareController : Controller
    {
        // GET: Customer/HosoShare
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        //lấy danh sách những hồ sơ đã share của mình cho người khác
        public JsonResult hsshare()
        {
            var rs = db.shareFiles.Where(x => x.codeShare == User.Identity.Name).Select(x => new
            {
                x.codeShare,
                x.codeTake,
                x.hosoID,
                x.noidung,
                x.idUser
            }).ToList();
            return Json(new { dt = rs}, JsonRequestBehavior.AllowGet);
        }
    }
}