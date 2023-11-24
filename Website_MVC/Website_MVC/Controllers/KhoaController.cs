using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MVC.Models;
namespace Website_MVC.Controllers
{
    public class KhoaController : Controller
    {
        //
        // GET: /Khoa/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListKhoa()
        {
            QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            List<KHOA> dsKhoa = db.KHOAs.ToList();
            return View(dsKhoa);
        }
        public ActionResult ListSVKhoa(int MaKhoa)
        {
            QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            List<SINHVIEN> dsSinhVien = db.SINHVIENs
                .Where(x => x.MaKhoa == MaKhoa)
                .ToList();
            return View(dsSinhVien);
        }

        private string TaoMaKhoa()
        {
            DateTime now = DateTime.Now;
            string ma = now.ToString("fff"); // Lấy 3 chữ số cuối cùng
            return ma;
        }
        public ActionResult Create()
        {
            if(Request.Form.Count > 0)
            {
                string TenKhoa = Request.Form["TenKhoa"];
                string DienThoai = Request.Form["DienThoai"];
                QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
                KHOA objkhoa = new KHOA();
                objkhoa.Makhoa = int.Parse(TaoMaKhoa());
                objkhoa.Tenkhoa = TenKhoa;
                objkhoa.Dienthoai = int.Parse(DienThoai);
                db.KHOAs.InsertOnSubmit(objkhoa);
                db.SubmitChanges();
                return RedirectToAction("ListKhoa");
            }
            return View();
        }

        

        public ActionResult Details(string MaKhoa)
        {
            QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            KHOA khoa = db.KHOAs.FirstOrDefault(x => x.Makhoa == int.Parse(MaKhoa));
            return View(khoa);
        }

        public ActionResult Edit(string MaKhoa)
        {
            QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            KHOA k = db.KHOAs.FirstOrDefault(a => a.Makhoa == int.Parse(MaKhoa));

            if(Request.Form.Count == 0)
            {
                return View(k);
            }
            string TenKhoa = Request.Form["TenKhoa"];
            string DienThoai = Request.Form["DienThoai"];
            k.Tenkhoa = TenKhoa;
            k.Dienthoai = int.Parse(DienThoai);
            db.SubmitChanges();
            return RedirectToAction("ListKhoa");
            
        }

        public ActionResult Delete(string MaKhoa)
        {
            QuanlytruonghocDataContext db =new QuanlytruonghocDataContext();
            KHOA khoa = db.KHOAs.FirstOrDefault(x=>x.Makhoa==int.Parse(MaKhoa));
            if(khoa != null)
            {
                db.KHOAs.DeleteOnSubmit(khoa);
                db.SubmitChanges();
            }
            return RedirectToAction("ListKhoa");
        }
	}
}