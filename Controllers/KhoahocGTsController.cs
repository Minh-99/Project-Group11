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
    public class KhoahocGTsController : Controller
    {
        private TailieuDBContext db = new TailieuDBContext();

        // GET: KhoahocGTs
        public ActionResult Index()
        {
            return View(db.KhoahocGTs.ToList());
        }

        // GET: KhoahocGTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocGT khoahocGT = db.KhoahocGTs.Find(id);
            if (khoahocGT == null)
            {
                return HttpNotFound();
            }
            return View(khoahocGT);
        }

        // GET: KhoahocGTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoahocGTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Picture,TenKH,GiaoVien,Thoigian,Noidung,Giaotrinh,hoatdong,hocphi")] KhoahocGT khoahocGT)
        {
            if (ModelState.IsValid)
            {
                db.KhoahocGTs.Add(khoahocGT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoahocGT);
        }

        // GET: KhoahocGTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocGT khoahocGT = db.KhoahocGTs.Find(id);
            if (khoahocGT == null)
            {
                return HttpNotFound();
            }
            return View(khoahocGT);
        }

        // POST: KhoahocGTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Picture,TenKH,GiaoVien,Thoigian,Noidung,Giaotrinh,hoatdong,hocphi")] KhoahocGT khoahocGT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoahocGT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoahocGT);
        }

        // GET: KhoahocGTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoahocGT khoahocGT = db.KhoahocGTs.Find(id);
            if (khoahocGT == null)
            {
                return HttpNotFound();
            }
            return View(khoahocGT);
        }

        // POST: KhoahocGTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoahocGT khoahocGT = db.KhoahocGTs.Find(id);
            db.KhoahocGTs.Remove(khoahocGT);
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
