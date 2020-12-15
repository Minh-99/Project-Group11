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
    public class TintucsController : Controller
    {
        private TailieuDBContext db = new TailieuDBContext();

        // GET: Tintucs
        public ActionResult Index()
        {
            return View(db.tintucs.ToList());
        }

        // GET: Tintucs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: Tintucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Picture,PictureUpload,Tieude,Noidung,Xemthem")] Tintuc tintuc)
        {
            tintuc.Picture = new byte[tintuc.PictureUpload.ContentLength];
            tintuc.PictureUpload.InputStream.Read(tintuc.Picture, 0, tintuc.PictureUpload.ContentLength);
            if (ModelState.IsValid)
            {
                db.tintucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tintuc);
        }

        // GET: Tintucs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Picture,PictureUpload,Tieude,Noidung,Xemthem")] Tintuc tintuc)
        {
            tintuc.Picture = new byte[tintuc.PictureUpload.ContentLength];
            tintuc.PictureUpload.InputStream.Read(tintuc.Picture, 0, tintuc.PictureUpload.ContentLength);
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tintuc);
        }

        // GET: Tintucs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Tintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tintuc tintuc = db.tintucs.Find(id);
            db.tintucs.Remove(tintuc);
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
