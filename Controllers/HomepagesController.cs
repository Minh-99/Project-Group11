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
    public class HomepagesController : Controller
    {
        private TailieuDBContext db = new TailieuDBContext();

        // GET: Homepages
        public ActionResult Index()
        {
            return View(db.homepages.ToList());
        }

        // GET: Homepages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homepage homepage = db.homepages.Find(id);
            if (homepage == null)
            {
                return HttpNotFound();
            }
            return View(homepage);
        }

        // GET: Homepages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homepages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDlich,Picture1,Picture2,Picture3,Picture4,Picture5,ForeignFollower,StudentsEnrolled,ClassesComplete,CertifiedTeachers,PictureGV,TenGV,MotaGV,PictureGV1,TenGV1,MotaGV1,PictureGV2,TenGV2,MotaGV2,PictureHV,TenHV,DiemHV,PictureHV1,TenHV1,DiemHV1,PictureHV2,TenHV2,DiemHV2,PictureHV3,TenHV3,DiemHV3,PictureHV4,TenHV4,DiemHV4,PictureHV5,TenHV5,DiemHV5,Khoahoc,Makhoahoc,Khaigiang,Thoigian,lichhoc,sobuoi,Khoahoc1,Makhoahoc1,Khaigiang1,Thoigian1,lichhoc1,sobuoi1,Khoahoc2,Makhoahoc2,Khaigiang2,Thoigian2,lichhoc2,sobuoi2,Khoahoc3,Makhoahoc3,Khaigiang3,Thoigian3,lichhoc3,sobuoi3,Khoahoc4,Makhoahoc4,Khaigiang4,Thoigian4,lichhoc4,sobuoi4")] Homepage homepage)
        {
            if (ModelState.IsValid)
            {
                db.homepages.Add(homepage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homepage);
        }

        // GET: Homepages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homepage homepage = db.homepages.Find(id);
            if (homepage == null)
            {
                return HttpNotFound();
            }
            return View(homepage);
        }

        // POST: Homepages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDlich,Picture1,Picture2,Picture3,Picture4,Picture5,ForeignFollower,StudentsEnrolled,ClassesComplete,CertifiedTeachers,PictureGV,TenGV,MotaGV,PictureGV1,TenGV1,MotaGV1,PictureGV2,TenGV2,MotaGV2,PictureHV,TenHV,DiemHV,PictureHV1,TenHV1,DiemHV1,PictureHV2,TenHV2,DiemHV2,PictureHV3,TenHV3,DiemHV3,PictureHV4,TenHV4,DiemHV4,PictureHV5,TenHV5,DiemHV5,Khoahoc,Makhoahoc,Khaigiang,Thoigian,lichhoc,sobuoi,Khoahoc1,Makhoahoc1,Khaigiang1,Thoigian1,lichhoc1,sobuoi1,Khoahoc2,Makhoahoc2,Khaigiang2,Thoigian2,lichhoc2,sobuoi2,Khoahoc3,Makhoahoc3,Khaigiang3,Thoigian3,lichhoc3,sobuoi3,Khoahoc4,Makhoahoc4,Khaigiang4,Thoigian4,lichhoc4,sobuoi4")] Homepage homepage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homepage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homepage);
        }

        // GET: Homepages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homepage homepage = db.homepages.Find(id);
            if (homepage == null)
            {
                return HttpNotFound();
            }
            return View(homepage);
        }

        // POST: Homepages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homepage homepage = db.homepages.Find(id);
            db.homepages.Remove(homepage);
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
