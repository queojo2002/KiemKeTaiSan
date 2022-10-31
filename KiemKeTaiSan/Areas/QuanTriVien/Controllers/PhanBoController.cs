using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public JsonResult Select_PhanBo_By_MaPhong(int MaPhong)
        {
            var get_data = from s in db.PhanBos
                           where s.MaPhong == MaPhong
                           join ts1 in db.TaiSans on s.MaTS equals ts1.MaTS
                           join nts in db.NhomTaiSans on ts1.MaNhomTS equals nts.MaNhomTS
                           select new { 
                               s.MaTS, 
                               ts1.MaNhomTS, 
                               nts.TenNhomTS, 
                               ts1.TenTS, 
                               ts1.GiaTri, 
                               s.SoLuong, 
                               ts1.HangSanXuat, 
                               ts1.NamSanXuat, 
                               ts1.NuocSanXuat, 
                               s.GhiChu, 
                               s.NgayCapNhat 
                           };
            return Json(new { data = get_data.OrderByDescending(s => s.NgayCapNhat) }, JsonRequestBehavior.AllowGet);



        }


        [HttpPost]
        public JsonResult Insert_PhanBo_SoLuong_One(PhanBo pb)
        {
            var check_is = from s in db.PhanBos
                           where s.MaTS == pb.MaTS
                           where s.MaPhong == pb.MaPhong
                           select s; // kiểm tra TS đã có trong phòng chưa

            if (check_is.Count() <= 0) // nếu chưa có 
            {
                try
                {
                    // update lại tài sản
                    var ts = db.TaiSans.SingleOrDefault(s => s.MaTS == pb.MaTS);
                    if (ts.SoLuong >= 1)
                    {
                        if (pb.SoLuong > ts.SoLuong)
                        {
                            return Json(new { Message = "Số lượng không hợp lệ", code = false });
                        }
                        ts.SoLuong -= pb.SoLuong;
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
            }else
            { // nếu có rồi
                try
                {
                    // update lại tài sản
                    var ts = db.TaiSans.SingleOrDefault(s => s.MaTS == pb.MaTS);
                    if (ts.SoLuong >= 1)
                    {
                        if (pb.SoLuong > ts.SoLuong)
                        {
                            return Json(new { Message = "Số lượng không hợp lệ", code = false });
                        }
                        ts.SoLuong -= pb.SoLuong;
                        db.SubmitChanges();

                        // update vào phân bố
                        check_is.SingleOrDefault().NgayCapNhat = DateTime.Now;
                        check_is.SingleOrDefault().SoLuong += pb.SoLuong;
                        if (string.IsNullOrEmpty(pb.GhiChu))
                        {
                            check_is.SingleOrDefault().GhiChu = "Không có";
                        }
                        
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
}