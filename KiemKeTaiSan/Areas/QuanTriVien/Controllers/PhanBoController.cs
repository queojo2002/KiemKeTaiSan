using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemKeTaiSan.Models;
namespace KiemKeTaiSan.Areas.QuanTriVien.Controllers
{
    public class PhanBoController : Controller
    {
        kktsDataContext db = new kktsDataContext();

        // GET: QuanTriVien/PhanBo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemDanhSachPhanBo()
        {
            return View();
        }

        public ActionResult PhanBoThietBi()
        {
            return View();
        }



        [HttpGet]
        public JsonResult Select_PhanBo()
        {
            var get_data = from s in db.PhanBos
                           group s by s.MaPhong into g
                           join p1 in db.Phongs on g.First().MaPhong equals p1.MaPhong
                           select new {MaPhong = g.First().MaPhong,SoLuong = g.Sum(pc => pc.SoLuong),TenPhong = p1.TenPhong, NgayCapNhat = g.First().NgayCapNhat, NgayTao = g.First().NgayTao};
           
                return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);

            
            
        }


        [HttpGet]
        public JsonResult Check_PhanBo(int iMaPhong)
        {
            var get_data = from s in db.PhanBos.OrderByDescending(a => a.MaPhong)
                            where s.MaPhong == iMaPhong
                            select new { s.MaPhong, s.GhiChu, s.NgayCapNhat };
            if (get_data.Count() >= 1)
            {
                return Json(new { code = 1 }, JsonRequestBehavior.AllowGet);

            }else
            {            
                return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public JsonResult Insert_PhanBo(PhanBo pb)
        {
            pb.NgayTao = DateTime.Now;
            pb.NgayCapNhat = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(pb.GhiChu))
                {
                    pb.GhiChu = "Không có";
                }
                db.PhanBos.InsertOnSubmit(pb);
                db.SubmitChanges();
                return Json(new { Message = "SUCCESS", code = true });
            }

            return Json(new { Message = "ERROR", code = false });
        }



    }
}