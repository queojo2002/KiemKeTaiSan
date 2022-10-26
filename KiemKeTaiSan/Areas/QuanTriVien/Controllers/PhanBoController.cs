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
                           
                           select new { MaPhong = g.First().MaPhong, SoLuong = g.Sum(pc => pc.SoLuong), TenPhong = p1.TenPhong, NgayCapNhat = g.First().NgayCapNhat, NgayTao = g.First().NgayTao };

            return Json(new { data = get_data.OrderByDescending(s => s.NgayCapNhat) }, JsonRequestBehavior.AllowGet);



        }

        [HttpGet]
        public JsonResult Select_PhanBo_Theo_MaPhong(int MaPhong)
        {
            var get_data = from s in db.PhanBos
                           where s.MaPhong == MaPhong
                           join ts1 in db.TaiSans on s.MaTS equals ts1.MaTS
                           join nts in db.NhomTaiSans on ts1.MaNhomTS equals nts.MaNhomTS
                           select new { s.MaTS, ts1.MaNhomTS, nts.TenNhomTS, ts1.TenTS, ts1.GiaTri, s.SoLuong, ts1.HangSanXuat, ts1.NamSanXuat, ts1.NuocSanXuat, s.GhiChu, s.NgayCapNhat };

           // select new { MaPhong = s.MaPhong, SoLuong = g.Sum(pc => pc.SoLuong), TenPhong = p1.TenPhong, NgayCapNhat = g.First().NgayCapNhat, NgayTao = g.First().NgayTao };

            return Json(new { data = get_data.OrderByDescending(s => s.NgayCapNhat) }, JsonRequestBehavior.AllowGet);



        }


        [HttpGet]
        public JsonResult LoadTaiSan_TheoMaPhong(int iMaPhong, int iMaTS)
        {
            var get_data = from s in db.PhanBos.OrderByDescending(a => a.MaPhong)
                           where s.MaPhong == iMaPhong
                           where s.MaTS == iMaTS
                           select new { s.MaPhong, s.MaTS, s.GhiChu, s.NgayCapNhat };
            if (get_data.Count() <= 0)
            {
                return Json(new { code = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = true }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public JsonResult Insert_PhanBo_SoLuong_One(PhanBo pb)
        {
            var check_is = from s in db.PhanBos.OrderByDescending(a => a.MaPhong)
                           where s.MaTS == pb.MaTS
                           select s;
            if (check_is.Count() < 0)
            {
                return Json(new { Message = "Thêm mới thất bại", code = false });
            }
            try
            {
                

                // update lại tài sản
                var ts = db.TaiSans.SingleOrDefault(s => s.MaTS == pb.MaTS);
                if (ts.SoLuong >= 1)
                {
                    ts.SoLuong -= 1;
                    db.SubmitChanges();

                    // insert vào phân bố
                    pb.NgayTao = DateTime.Now;
                    pb.NgayCapNhat = DateTime.Now;
                    if (string.IsNullOrEmpty(pb.GhiChu))
                    {
                        pb.GhiChu = "Không có";
                    }
                    db.PhanBos.InsertOnSubmit(pb);
                    db.SubmitChanges();
                    return Json(new { Message = "Thêm mới thành công", code = true });
                }
                else
                {
                    return Json(new { Message = "Thêm mới thất bại, do tài sản không đủ số lượng", code = true });
                }


                
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message, code = false });
            }
        }



    }
}