using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Customer.Controllers
{
    public class NguoiNhapCanhController : Controller
    {
        Model1 db = new Model1();
        // GET: Customer/NguoiNhapCanh
        public ActionResult Index(int id)
        {
            List<nguoidung> ct = new List<nguoidung>();
            ct = db.nguoidungs.Where(x => x.idUser == id).ToList();
            return View(ct);
        }
    }
}