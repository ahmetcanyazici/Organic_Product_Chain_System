using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrganikUrunZincirTakip.Filter;
using OrganikUrunZincirTakip.Models;

namespace OrganikUrunZincirTakip.Controllers
{
    [SaticiAuth]
    public class SatisController : Controller
    {
        private OrganikUrunDBContext db = new OrganikUrunDBContext();

        // GET: Satis
        public ActionResult Index()
        {
            var satis = db.Satis.Include(s => s.Nakliye).Include(s => s.User);
            return View(satis.ToList());
        }

        // GET: Satis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sati sati = db.Satis.Find(id);
            if (sati == null)
            {
                return HttpNotFound();
            }
            return View(sati);
        }

        // GET: Satis/Create
        public ActionResult Create()
        {
            ViewBag.NakliyeID = new SelectList(db.Nakliyes, "NakliyeID", "NakliyeID");
            return View();
        }

        // POST: Satis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatısID,NakliyeID,SatısTarih,SatisAcıklama,UserId")] Sati sati)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(Session["KisiId"].ToString());
                sati.UserId = Id;
                db.Satis.Add(sati);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NakliyeID = new SelectList(db.Nakliyes, "NakliyeID", "NakliyeID", sati.NakliyeID);
            return View(sati);
        }

        // GET: Satis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sati sati = db.Satis.Find(id);
            if (sati == null)
            {
                return HttpNotFound();
            }
            ViewBag.NakliyeID = new SelectList(db.Nakliyes, "NakliyeID", "NakliyeID", sati.NakliyeID);
            return View(sati);
        }

        // POST: Satis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatısID,NakliyeID,SatısTarih,SatisAcıklama,UserId")] Sati sati)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sati).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NakliyeID = new SelectList(db.Nakliyes, "NakliyeID", "NakliyeID", sati.NakliyeID);
            return View(sati);
        }

        // GET: Satis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sati sati = db.Satis.Find(id);
            if (sati == null)
            {
                return HttpNotFound();
            }
            return View(sati);
        }

        // POST: Satis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sati sati = db.Satis.Find(id);
            db.Satis.Remove(sati);
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
