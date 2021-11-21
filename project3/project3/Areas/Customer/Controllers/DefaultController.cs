using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Areas.Customer.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Customer/Default
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
       //hiển thị tất cả những hồ sơ của người đang đăng nhập
        public JsonResult hienthi()
        {
            var ds = db.HoSoes.Where(x => x.AdminCP.code == User.Identity.Name).Select(x => new
            {
                x.idHoso,      
               // x.idUser,        
                x.ngayNhapCanh,
                x.fullname,   
                x.visa,       
                x.nhanxet,
                x.chuyenbay,
                x.isdelete,                                           
            }).ToList();
            return Json(new { dt=ds }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        //lấy danh sách để chia sẻ file
        public JsonResult dsAdmin()
        {
            var ds = db.AdminCPs.Select(x => new
            {
                x.id,
                x.code,
                x.fullname,
                x.email,
                //x.quoctich
            }).ToList();
            return Json(new {ds} , JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        //truyền vào các mã để lưu vào trong bảng share file
        public JsonResult Share(string codeShare, int codeTake,int useFileID, string noidung)
        {
            shareFile sf = new shareFile
            {
                codeShare = codeShare,
                codeTake = db.AdminCPs.Where(x=>x.id==codeTake).Select(x=>x.code).FirstOrDefault(),              
                hosoID = useFileID,
                noidung = noidung,
              //  idUser = idUser,
            };
            var rs = db.shareFiles.Add(sf);
            db.SaveChanges();
            return Json( new {sf, ms = "thêm thành công", },JsonRequestBehavior.AllowGet);
        }
    }
}