using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group11.Models;

namespace Group11.Controllers
{
    public class KhoahocToeicsController : Controller
    {
        private TailieuDBContext db = new TailieuDBContext();

        // GET: KhoahocToeics
        public ActionResult Index()
        {
            return View(db.KhoahocToeics.ToList());
        }

        // GET: KhoahocToeics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocToeic khoahocToeic = db.KhoahocToeics.Find(id);
            if (khoahocToeic == null)
            {
                return HttpNotFound();
            }
            return View(khoahocToeic);
        }

        // GET: KhoahocToeics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoahocToeics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Picture,TenKH,GiaoVien,Thoigian,Noidung,Giaotrinh,hoatdong,hocphi")] KhoahocToeic khoahocToeic)
        {
            if (ModelState.IsValid)
            {
                db.KhoahocToeics.Add(khoahocToeic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoahocToeic);
        }

        // GET: KhoahocToeics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocToeic khoahocToeic = db.KhoahocToeics.Find(id);
            if (khoahocToeic == null)
            {
                return HttpNotFound();
            }
            return View(khoahocToeic);
        }

        // POST: KhoahocToeics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Picture,TenKH,GiaoVien,Thoigian,Noidung,Giaotrinh,hoatdong,hocphi")] KhoahocToeic khoahocToeic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoahocToeic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoahocToeic);
        }

        // GET: KhoahocToeics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocToeic khoahocToeic = db.KhoahocToeics.Find(id);
            if (khoahocToeic == null)
            {
                return HttpNotFound();
            }
            return View(khoahocToeic);
        }

        // POST: KhoahocToeics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoahocToeic khoahocToeic = db.KhoahocToeics.Find(id);
            db.KhoahocToeics.Remove(khoahocToeic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
