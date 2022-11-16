using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemKeTaiSan.Models;
namespace KiemKeTaiSan.Areas.QuanTriVien.Controllers
{
    public class NguoiDungController : Controller
    {
        kktsDataContext db = new kktsDataContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}