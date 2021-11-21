using project3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Admin.Controllers
{
    public class hosoController : Controller
    {
        // GET: Admin/hoso       
        Model1 db = new Model1();
        // GET: Admin/Hoso
        public ActionResult Index()
        {
            return View(db.HoSoes.ToList());
        }
        public JsonResult Details(int id)
        {
            var rs = db.HoSoes.Find(id);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult create(HoSo hs)
        {
            // bool isdelete = false;
            try
            {
                var rs = db.HoSoes.Add(hs);
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
            HoSo cthso = db.HoSoes.Where(x => x.idHoso == id).FirstOrDefault();
            db.HoSoes.Remove(cthso);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //sua viet 2 ham
        public JsonResult edit(HoSo hoso)
        {
            db.Entry(hoso).State = System.Data.Entity.EntityState.Modified;
            var rs = db.SaveChanges();
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get(int id)
        {
            var ds = db.HoSoes.Where(x => x.idHoso == id).Select(x => new //select de lay cac thuoc tinh can lay,find la lay het,o day minh bo thuoc tinh updatedate nen phai dung select?cau nay la sao?
            {
                idHoso = x.idHoso,
                ngayNhapCanh = x.ngayNhapCanh,
                fullname = x.fullname,
                visa = x.visa,
                chuyenbay = x.chuyenbay,
                nhanxet = x.nhanxet,
                idadmincp = x.idadmincp
            }).SingleOrDefault();
            return Json(new { dt = ds }, JsonRequestBehavior.AllowGet);//lay dt
        }
    }
}