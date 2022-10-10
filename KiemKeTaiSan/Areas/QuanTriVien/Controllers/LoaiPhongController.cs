using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            return View();
        }

        [HttpGet]
        public JsonResult Get_LoaiPhong()
        {
            var get_data = from s in db.LoaiPhongs.OrderByDescending(a => a.NgayCapNhat)
                           select new { s.MaLP, s.TenLP, s.GhiChu, s.NgayCapNhat };
            return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Get_LoaiPhong_By_MaLP(int MaLP)
        {
            var get_data = from s in db.LoaiPhongs.Where(lp => lp.MaLP == MaLP)
                           select new { s.MaLP, s.TenLP, s.GhiChu, s.NgayCapNhat };
            if (get_data.Count() > 0)
            {
                return Json(new { data = get_data }, JsonRequestBehavior.AllowGet);
            }else
            {
                return Json(new { Message = "GetDataError" }, JsonRequestBehavior.AllowGet);
            } 
        }


        [HttpPost]
        public JsonResult Update_LoaiPhong_By_MaLP(LoaiPhong lp)
        {
            var get_data = db.LoaiPhongs.SingleOrDefault(n => n.MaLP == int.Parse(lp.MaLP.ToString()));

            if (get_data != null)
            {
                if (ModelState.IsValid)
                {
                    get_data.TenLP = lp.TenLP;
                    get_data.GhiChu = lp.GhiChu;
                    get_data.NgayCapNhat = DateTime.Now;
                    db.SubmitChanges();
                    return Json(new { Message = "Chỉnh sửa loại phòng có ID: " + lp.MaLP + " thành công!!!", succcess = true });
                }
                else
                {
                    return Json(new { Message = "Error_ModelState", succcess = false });
                }
            }
            else
            {
                return Json(new { Message = "Erorr_GetData", succcess = false });
            }
        }

        [HttpPost]
        public JsonResult Insert_LoaiPhong(LoaiPhong lp)
        {
            if (String.IsNullOrEmpty(lp.TenLP))
            {
                return Json(new { Message = "Chưa nhập tên loại phòng", succcess = false });
            }else
            {
                lp.NgayCapNhat = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(lp.GhiChu))
                    {
                        lp.GhiChu = "Không có";
                    }
                    db.LoaiPhongs.InsertOnSubmit(lp);
                    db.SubmitChanges();
                    return Json(new { Message = "SUCCESS", succcess = true});
                }
            }
            return Json(new { Message = "ERROR", succcess = false});
        }
    }
}