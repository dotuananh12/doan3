using project3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.nguoidungs.ToList());
        }

        public JsonResult Details(int id)
        {
            var rs = db.nguoidungs.Find(id);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult create(nguoidung nd)
        {
            try
            {
                var rs = db.nguoidungs.Add(nd);
                db.SaveChanges();
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

        public JsonResult edit(nguoidung nguoidung)
        {
            db.Entry(nguoidung).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult get(int id)
        {
            var ds = db.nguoidungs.Where(x => x.idUser == id).Select(x => new //select de lay cac thuoc tinh can lay,find la lay het,o day minh bo thuoc tinh updatedate nen phai dung select?cau nay la sao?
            {
                idUser = x.idUser,//giống y hết nhau ms dc
                code = x.code,
                idRole = x.idRole,
                fullname = x.fullname,
                password = x.password,
                phonenumber = x.phonenumber,
                email = x.email,
                gioitinh = x.gioitinh,
                quoctich = x.quoctich,
                visa=x.visa,
                ngaycap=x.ngaycap,
                hansudung=x.hansudung,
                idHoso=x.idHoso
            }).ToList().SingleOrDefault();
            return Json(new { dt = ds }, JsonRequestBehavior.AllowGet);//lay dt
        }
        public ActionResult delete(int id)
        {
            nguoidung ndu = db.nguoidungs.Where(x => x.idUser == id).FirstOrDefault();
            db.nguoidungs.Remove(ndu);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}