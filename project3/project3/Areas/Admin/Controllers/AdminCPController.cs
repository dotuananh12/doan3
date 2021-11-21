using project3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Admin.Controllers
{
    public class AdminCPController : Controller
    {
        // GET: Admin/AdminCP
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.AdminCPs.ToList());
        }
        public JsonResult Details(int id)
        {
            var rs = db.AdminCPs.Find(id);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult create(AdminCP adm)
        {
            // bool isdelete = false;
            try
            {
                var rs = db.AdminCPs.Add(adm);
                db.SaveChanges();
                //isdelete = true;
                return Json(new { rs, message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var err in e.EntityValidationErrors)
                {
                    foreach (var thisErr in err.ValidationErrors)
                    {

                        var errorMessage = thisErr.ErrorMessage;
                        // return Json(new { errorMessage = "tạo thông tin thất bại" },JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public ActionResult delete(int id)
        {
            AdminCP admc = db.AdminCPs.Where(x => x.id == id).FirstOrDefault();
            db.AdminCPs.Remove(admc);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //sua viet 2 ham
        public JsonResult edit(AdminCP admcp)
        {
            db.Entry(admcp).State = System.Data.Entity.EntityState.Modified;
            var rs = db.SaveChanges();
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get(int id)
        {
            var ds = db.AdminCPs.Where(x => x.id == id).Select(x => new 
            {
                id = x.id,
                code = x.code,
                email = x.email,
                fullname = x.fullname,
                password = x.password,
                role = x.role,
                sdt = x.sdt,
                ngaysinh = x.ngaysinh
            }).ToList().SingleOrDefault();
            return Json(new { dt = ds }, JsonRequestBehavior.AllowGet);//lay dt
        }
    }
}