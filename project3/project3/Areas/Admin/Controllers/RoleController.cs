using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        public JsonResult Details(int id)
        {
            var rs = db.Roles.Find(id);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult create(Role rl)

        {
            try
            {
                var rs = db.Roles.Add(rl);
                db.SaveChanges();
                return Json(new { rs, message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { errorMessage = "tạo thông tin thất bại" }, JsonRequestBehavior.AllowGet);
            }
            // return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult edit(Role role)
        {
            db.Entry(role).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult get(string id)
        {
            var ds = db.Roles.Where(x => x.idRole == id).Select(x => new //select de lay cac thuoc tinh can lay,find la lay het,o day minh bo thuoc tinh updatedate nen phai dung select?cau nay la sao?
            {
                idRole = x.idRole,//giống y hết nhau ms dc
                rolecode = x.rolecode,
                NameChucvu = x.NameChucvu,

            }).ToList().SingleOrDefault();
            return Json(new { dt = ds }, JsonRequestBehavior.AllowGet);//lay dt
        }
        public ActionResult delete(string id)
        {
            Role rol = db.Roles.Where(x => x.idRole == id).FirstOrDefault();
            db.Roles.Remove(rol);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}