using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project3.Models;
namespace project3.Areas.Customer.Controllers
{
    public class ChitietHosoNhanController : Controller
    {
        Model1 db = new Model1();
        // GET: Customer/ChitietHosoNhan
        public ActionResult Index(int id)
        {
            List<ChiTietHoSo> ct = new List<ChiTietHoSo>();
            ct = db.ChiTietHoSoes.Where(x => x.idHoSo == id).ToList();
            return View(ct);           
        }
    }
}