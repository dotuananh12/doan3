using project3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Admin.Controllers
{
    public class FileHoSoController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Hoso
        public ActionResult Index()
        {
            return View(db.FileHoSoes.ToList());
        }
        public JsonResult Details(int idFileHoSo)
        {
            var rs = db.FileHoSoes.Find(idFileHoSo);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult create(FileHoSo fhs)
        {
            // bool isdelete = false;
            try
            {
                var rs = db.FileHoSoes.Add(fhs);
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
            FileHoSo fhso = db.FileHoSoes.Where(x => x.idFileHoSo == id).FirstOrDefault();
            db.FileHoSoes.Remove(fhso);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //sua viet 2 ham
        public JsonResult edit(FileHoSo fhoso)
        {
            db.Entry(fhoso).State = System.Data.Entity.EntityState.Modified;
            var rs = db.SaveChanges();
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get(int id)
        {
            var ds = db.FileHoSoes.Where(x => x.idFileHoSo == id).Select(x => new //select de lay cac thuoc tinh can lay,find la lay het,o day minh bo thuoc tinh updatedate nen phai dung select)
            {
                idFileHoSo = x.idFileHoSo,
                idChiTietHoSo = x.idChiTietHoSo,
                filename = x.filename,
                filelink = x.filelink,
                createBy = x.createBy,
                createDate = x.createDate,
            }).ToList().SingleOrDefault();
            return Json(new { dt = ds }, JsonRequestBehavior.AllowGet);//lay dt
        }
    }
}