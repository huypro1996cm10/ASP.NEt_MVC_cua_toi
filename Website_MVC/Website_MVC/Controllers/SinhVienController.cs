using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MVC.Models;
namespace Website_MVC.Controllers
{
    public class SinhVienController : Controller
    {
        //
        // GET: /SinhVien/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListSV()
        {   // C1:
            QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            List<SINHVIEN> dsSinhvien = db.SINHVIENs.ToList();
            return View(dsSinhvien);

            //C2:
            //QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            //List<SINHVIEN> dsSinhvien = (from sv in db.SINHVIENs
            //                             select sv).ToList();
            //return View(dsSinhvien);


            
            
        }

        
        public ActionResult TableSv()
        {
            //QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            //List<SINHVIEN> dsSinhvien = db.SINHVIENs.ToList();
            //ViewBag.dsSinhVien = dsSinhvien;
            //return View();
            //
            //QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            //List<SINHVIEN> dsSinhvien = (from sv in db.SINHVIENs select sv).ToList();
            //return View(dsSinhvien);

            QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            List<SINHVIEN> dsSinhvien = new List<SINHVIEN>();

            if (Request.QueryString.Count > 0)
            {
                int minYear = int.Parse(Request.QueryString["minYear"]);
                int maxYear = int.Parse(Request.QueryString["maxYear"]);
                dsSinhvien = db.SINHVIENs
                    .Where(x => x.Namsinh >= minYear && x.Namsinh <= maxYear)
                    .ToList();

            }
            return View(dsSinhvien);
        }

        public ActionResult Details(int id)
        {
            QuanlytruonghocDataContext db = new QuanlytruonghocDataContext();
            SINHVIEN sv = db.SINHVIENs.FirstOrDefault(x => x.MaSV == id);
            return View(sv);
        }
	}
}