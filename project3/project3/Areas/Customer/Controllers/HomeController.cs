using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        // GET: Customer/Home
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        //lấy dữ liệu của người đăng nhập vào
        public JsonResult getUse()
        {        
            var ds = db.AdminCPs.Where(x => x.code == User.Identity.Name).Select(x => new
            {
                fullname = x.fullname,              
                sohoso=db.HoSoes.Count(d=>d.idadmincp==x.id),
                hscs = db.shareFiles.Count(s => s.codeShare == User.Identity.Name),
                hsn =db.shareFiles.Count(s=>s.codeTake==User.Identity.Name),             
                email = x.email,                             
            });
            if (ds.Count() != 1)
                return Json(new App_Service.ApiResult() { success = true, message = "False", data = null }, JsonRequestBehavior.AllowGet);
            return Json(new App_Service.ApiResult() { success = true, message = "True", data = ds.SingleOrDefault() }, JsonRequestBehavior.AllowGet);
        }
        // hàm Update
        public JsonResult get(string code)
        {
            var ds = db.AdminCPs.Where(x => x.code == User.Identity.Name).Select(x => new 
            {
       
                fullname = x.fullname,
                email = x.email,
                password = x.password,
                sdt = x.sdt,
                role = x.role,
                ngaysinh = x.ngaysinh
            }).SingleOrDefault();
            return Json(new { dt=ds }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult edit(nguoidung nd)
        {
            nd.idUser = db.AdminCPs.Where(x => x.code == User.Identity.Name).Select(x => x.id).FirstOrDefault();
            db.Entry(nd).State = System.Data.Entity.EntityState.Modified;
            //Sửa lấy ra id cần sửa
            db.Entry(nd).Property(x => x.code).IsModified = false;               
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}