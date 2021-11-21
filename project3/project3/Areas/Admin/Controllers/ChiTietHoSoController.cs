using project3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Admin.Controllers
{
    public class ChiTietHoSoController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Hoso
        public ActionResult Index()
        {
            return View(db.ChiTietHoSoes.ToList());
        }
        public JsonResult Details(int id)
        {
            var rs = db.ChiTietHoSoes.Find(id);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult create(ChiTietHoSo cths)
        {
            // bool isdelete = false;
            try
            {
                var rs = db.ChiTietHoSoes.Add(cths);
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
            ChiTietHoSo cthso = db.ChiTietHoSoes.Where(x => x.idChiTietHoSo == id).FirstOrDefault();
            db.ChiTietHoSoes.Remove(cthso);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //sua viet 2 ham
        public JsonResult edit(ChiTietHoSo cthoso)
        {
            db.Entry(cthoso).State = System.Data.Entity.EntityState.Modified;
            var rs = db.SaveChanges();
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get(int id)
        {
            var ds = db.ChiTietHoSoes.Where(x => x.idChiTietHoSo == id).Select(x => new //select de lay cac thuoc tinh can lay,find la lay het,o day minh bo thuoc tinh updatedate nen phai dung select?cau nay la sao?
            {
                idChiTietHoSo = x.idChiTietHoSo,
                idHoSo = x.idHoSo,
                chandoanCovid = x.chandoanCovid,
                ketluan = x.ketluan,
                Ghichu = x.Ghichu,
                TenNoiNhapCanh = x.TenNoiNhapCanh,
                createdate = x.createdate
            }).ToList().SingleOrDefault();
            return Json(new { dt = ds }, JsonRequestBehavior.AllowGet);//lay dt
        }
    }
}