using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemKeTaiSan.Models;
namespace KiemKeTaiSan.Areas.QuanTriVien.Controllers
{
    public class TaiSanController : Controller
    {
        kktsDataContext db = new kktsDataContext();

        // GET: QuanTriVien/TaiSan
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Select_LoaiTaiSan()
        {
            var get_data = from s in db.LoaiTaiSans.OrderByDescending(a => a.MaLoaiTS)
                           select new { s.MaLoaiTS, s.TenLoaiTS, s.GhiChu, s.NgayCapNhat };
            return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Select_NhomTaiSan()
        {
            var get_data = from s in db.NhomTaiSans.OrderByDescending(a => a.MaNhomTS)
                           join lts in db.LoaiTaiSans on s.MaLoaiTS equals lts.MaLoaiTS
                           select new { s.MaLoaiTS, s.MaNhomTS, lts.TenLoaiTS, s.TenNhomTS, s.GhiChu, s.NgayCapNhat };
            return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Select_TaiSan()
        {
            var get_data = from s in db.TaiSans.OrderByDescending(a => a.MaTS)
                           join nts in db.NhomTaiSans on s.MaNhomTS equals nts.MaNhomTS
                           join lts in db.LoaiTaiSans on nts.MaLoaiTS equals lts.MaLoaiTS
                           select new { s.MaTS, s.MaNhomTS, nts.TenNhomTS, lts.MaLoaiTS, lts.TenLoaiTS, s.TenTS, s.GiaTri, s.HangSanXuat, s.NamSanXuat, s.NuocSanXuat, s.GhiChu, s.NgayCapNhat };
            return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
        }

    }
}