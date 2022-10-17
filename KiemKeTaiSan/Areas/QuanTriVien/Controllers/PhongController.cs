using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemKeTaiSan.Models;
namespace KiemKeTaiSan.Areas.QuanTriVien.Controllers
{
    public class PhongController : Controller
    {
        kktsDataContext db = new kktsDataContext();
        // GET: QuanTriVien/Phong
        public ActionResult Index()
        {
            var listPhong = from cd in db.Phongs select cd;
            return View(listPhong);
        }

        [HttpGet]
        public JsonResult Select_LoaiPhong()
        {
            var get_data = from s in db.LoaiPhongs.OrderByDescending(a => a.MaLP)
                           select new { s.MaLP, s.TenLP, s.GhiChu, s.NgayCapNhat };
            return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Select_KhuVucPhong()
        {
            var get_data = from s in db.KhuVucPhongs.OrderByDescending(a => a.MaKV)
                           select new { s.MaKV, s.TenKV, s.GhiChu, s.NgayCapNhat };
            return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Select_Phong()
        {
            var get_data = from s in db.Phongs.OrderByDescending(a => a.MaKV)
                           join kvp in db.KhuVucPhongs on s.MaKV equals kvp.MaKV
                           join lp in db.LoaiPhongs on s.MaLP equals lp.MaLP
                           select new {s.MaPhong, s.MaKV, s.MaLP, s.TenPhong, kvp.TenKV, lp.TenLP, s.GhiChu, s.NgayCapNhat };
            return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
        }

    }
}