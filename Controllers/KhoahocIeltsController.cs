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
    public class KhoahocIeltsController : Controller
    {
        private TailieuDBContext db = new TailieuDBContext();

        // GET: KhoahocIelts
        public ActionResult Index()
        {
            return View(db.KhoahocIelts.ToList());
        }

        // GET: KhoahocIelts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocIelts khoahocIelts = db.KhoahocIelts.Find(id);
            if (khoahocIelts == null)
            {
                return HttpNotFound();
            }
            return View(khoahocIelts);
        }

        // GET: KhoahocIelts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoahocIelts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Picture,TenKH,GiaoVien,Thoigian,Noidung,Giaotrinh,hoatdong,hocphi")] KhoahocIelts khoahocIelts)
        {
            if (ModelState.IsValid)
            {
                db.KhoahocIelts.Add(khoahocIelts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoahocIelts);
        }

        // GET: KhoahocIelts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocIelts khoahocIelts = db.KhoahocIelts.Find(id);
            if (khoahocIelts == null)
            {
                return HttpNotFound();
            }
            return View(khoahocIelts);
        }

        // POST: KhoahocIelts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Picture,TenKH,GiaoVien,Thoigian,Noidung,Giaotrinh,hoatdong,hocphi")] KhoahocIelts khoahocIelts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoahocIelts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoahocIelts);
        }

        // GET: KhoahocIelts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocIelts khoahocIelts = db.KhoahocIelts.Find(id);
            if (khoahocIelts == null)
            {
                return HttpNotFound();
            }
            return View(khoahocIelts);
        }

        // POST: KhoahocIelts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoahocIelts khoahocIelts = db.KhoahocIelts.Find(id);
            db.KhoahocIelts.Remove(khoahocIelts);
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
