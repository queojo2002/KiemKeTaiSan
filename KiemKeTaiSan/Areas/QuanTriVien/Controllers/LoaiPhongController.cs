using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemKeTaiSan.Models;

namespace KiemKeTaiSan.Areas.QuanTriVien.Controllers
{
    public class LoaiPhongController : Controller
    {
        kktsDataContext db = new kktsDataContext();

        // GET: QuanTriVien/LoaiPhong
        public ActionResult Index()
        {
            var listLoaiPhong = from lp in db.LoaiPhongs select lp;
            return View(listLoaiPhong);
        }
    }
}