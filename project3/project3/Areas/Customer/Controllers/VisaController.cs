using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Customer.Controllers
{
    public class VisaController : Controller
    {
        // GET: Customer/Visa
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult layvisa()
        {
            var ds = db.nguoidungs.Where(x => x.code == User.Identity.Name).Select(x => new
            {
                x.visa,
                x.ngaycap,
                x.hansudung
            });
            return Json(new{ dt=ds}, JsonRequestBehavior.AllowGet);
        }
    }
}