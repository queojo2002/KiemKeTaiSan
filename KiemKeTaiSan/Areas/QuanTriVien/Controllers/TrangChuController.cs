using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemKeTaiSan.Areas.QuanTriVien.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: QuanTriVien/TrangChu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTraiPartial()
        {
            return PartialView();
        }







    }
}