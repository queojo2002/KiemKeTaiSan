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


    }
}