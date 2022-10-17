using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemKeTaiSan.Areas.QuanTriVien.Controllers
{
    public class PhanBoController : Controller
    {
        // GET: QuanTriVien/PhanBo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemDanhSachPhanBo()
        {
            return View();
        }
    }
}