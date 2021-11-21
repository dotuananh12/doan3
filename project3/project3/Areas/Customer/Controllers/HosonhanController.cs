using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Customer.Controllers
{
    public class HosonhanController : Controller
    {
        Model1 db = new Model1();
        // GET: Customer/Hosonhan
        public ActionResult Index()
        {
            List<shareFile> s = new List<shareFile>();
            s = db.shareFiles.Where(x => x.codeTake == User.Identity.Name).ToList();
            return View(s);
           
        }    
    }
}