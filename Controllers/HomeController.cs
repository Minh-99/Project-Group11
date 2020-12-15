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

namespace G11.Controllers
{
    public class HomeController : Controller
    {
        private TailieuDBContext db = new TailieuDBContext();


        public ActionResult Index()
        {
            return View(db.homepages.ToList());
        }
        //code mục khóa học
        public ActionResult GiaoTiep_kh()
        {
            ViewBag.Message = "";

            return View();
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
        // code mục tài liệu
        public ActionResult GiaoTiep_tl()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Toeic_tl()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Ielts_tl()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Tintuc
        public ActionResult Tintuc()
        {
            return View(db.tintucs.ToList());

        }
        // GET: Lienhe
        public ActionResult Lienhe()
        {
            return View();
        }
    }
}