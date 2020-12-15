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
    public class TailieuxController : Controller
    {
        private TailieuDBContext db = new TailieuDBContext();

        // GET: Tailieux
        public ActionResult Index()
        {
            var tailieus = db.tailieus.Include(t => t.GenresObj);
            return View(tailieus.ToList());
        }

        // GET: Tailieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tailieu tailieu = db.tailieus.Find(id);
            if (tailieu == null)
            {
                return HttpNotFound();
            }
            return View(tailieu);
        }

        // GET: Tailieux/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.genres, "genreID", "genreName");
            return View();
        }

        // POST: Tailieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,GenreID,Price,Picture,Rating,Sumary")] Tailieu tailieu)
        {
            tailieu.Picture = new byte[tailieu.PictureUpload.ContentLength];
            tailieu.PictureUpload.InputStream.Read(tailieu.Picture, 0, tailieu.PictureUpload.ContentLength);

            if (ModelState.IsValid)
            {
                db.tailieus.Add(tailieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.genres, "genreID", "genreName", tailieu.GenreID);
            return View(tailieu);
        }

        // GET: Tailieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tailieu tailieu = db.tailieus.Find(id);
            if (tailieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.genres, "genreID", "genreName", tailieu.GenreID);
            return View(tailieu);
        }

        // POST: Tailieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,GenreID,Price,Picture,Rating,Sumary")] Tailieu tailieu)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(tailieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.genres, "genreID", "genreName", tailieu.GenreID);
            return View(tailieu);
        }

        // GET: Tailieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tailieu tailieu = db.tailieus.Find(id);
            if (tailieu == null)
            {
                return HttpNotFound();
            }
            return View(tailieu);
        }

        // POST: Tailieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tailieu tailieu = db.tailieus.Find(id);
            db.tailieus.Remove(tailieu);
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
