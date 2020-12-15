using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Group11.Models;
using Microsoft.AspNet.Identity;


namespace Group11.Controllers
{
    public class Home_HVController : Controller
    {

        private TailieuDBContext db = new TailieuDBContext();

        public ActionResult Lienhe()
        {
            return View();
        }


        public ActionResult GiaoTiep()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult GiaoTiep_kh()
        {
            ViewBag.Message = "";

            return View(db.KhoahocGTs.ToList());
        }

        public ActionResult Toeic_kh()
        {
            ViewBag.Message = "Your contact page.";

            return View(db.KhoahocToeics.ToList());
        }
        public ActionResult Ielts_kh()
        {
            ViewBag.Message = "Your contact page.";

            return View(db.KhoahocIelts.ToList());
        }

        public ActionResult TKB()
        {
           
            return View();
        }

        public ActionResult Ielts()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // code mục tài liệu
        

        // GET: Home_HV
        public ActionResult Index()
        {
            return View(db.homepages.ToList());
        }
        public ActionResult Tailieu()
        {
            var movies = db.tailieus.Include(m => m.GenresObj);
            return View(movies.ToList());

        }
        public ActionResult Tintuc()
        {
            return View(db.tintucs.ToList());

        }
        public ActionResult AddToCart(int id, HoaDon hoaDon)
        {
            //Kiem tra Id movie ton tai hay khong
            var movie = db.tailieus.Where(x => x.ID == id).FirstOrDefault();
            if (movie == null)
            {
                return RedirectToAction("Index");
            }
            hoaDon = this.Session["HoaDon"] as HoaDon;
            if (hoaDon == null)
            {
                hoaDon = new HoaDon();
                hoaDon.NgayLap = DateTime.Now;
                hoaDon.ChiTietHoaDons = new List<ChiTietHoaDon>();
                this.Session["HoaDon"] = hoaDon;
                db.HoaDons.Add(hoaDon);
            }
            //Kiem tra don hang da co truoc do
            var chiTietHoaDon = hoaDon.ChiTietHoaDons.Where(x => x.MovieObj.ID == id).FirstOrDefault();
            if (chiTietHoaDon == null)
            {
                chiTietHoaDon = new ChiTietHoaDon();
                chiTietHoaDon.MaMovie = id;
                chiTietHoaDon.MovieObj = movie;
                chiTietHoaDon.HoaDonObj = hoaDon;
                chiTietHoaDon.SoLuong = 1;
                hoaDon.ChiTietHoaDons.Add(chiTietHoaDon);
            }
            else
            {
                chiTietHoaDon.SoLuong++;
            }
            db.SaveChanges();
            return View(hoaDon);
        }
        public ActionResult RemoveFromCart(int maTailieus)
        {
            var hoaDon = this.Session["HoaDon"] as HoaDon;
            var chiTietHoaDon = hoaDon.ChiTietHoaDons.Where(x
            => x.MovieObj.ID == maTailieus).FirstOrDefault();
            hoaDon.ChiTietHoaDons.Remove(chiTietHoaDon);
            return View("AddToCart", hoaDon);
        }
        public PartialViewResult Summary()
        {
            var hoaDon = this.Session["HoaDon"] as HoaDon;
            if (hoaDon == null)
            {
                return null;
            }
            return PartialView(hoaDon);
        }
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(ShippingDetail detail)
        {
            var hoaDon = this.Session["HoaDon"] as HoaDon;
            if (hoaDon.ChiTietHoaDons.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart isempty!");
            }
            if (ModelState.IsValid)
            {
                StringBuilder body = new StringBuilder().AppendLine("A new order has been submitted").AppendLine("---").AppendLine("Items:");
                foreach (var hoaDonChiTiet in hoaDon.ChiTietHoaDons)
                {
                    var subtotal = hoaDonChiTiet.MovieObj.Price * hoaDonChiTiet.SoLuong;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", hoaDonChiTiet.SoLuong, hoaDonChiTiet.MovieObj.Title, subtotal);
                }
                body.AppendFormat("Total order value: {0:c}", hoaDon.TongTien).AppendLine("---").AppendLine("Ship to:").AppendLine(detail.Name).AppendLine(detail.Address).AppendLine(detail.Mobile.ToString());
                EmailServiceNew.SendEmail(new IdentityMessage()
                {
                    Destination = detail.Email,
                    Subject = "New order submitted!",
                    Body = body.ToString()
                });
                this.Session["HoaDon"] = null;
                return View("CheckoutCompleted");
            }
            else
            {
                return View(new ShippingDetail());
            }
        }
    }
}