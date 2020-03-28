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
    [DepolayiciAuth]
    public class DepolamasController : Controller
    {
        private OrganikUrunDBContext db = new OrganikUrunDBContext();

        // GET: Depolamas
        public ActionResult Index()
        {
            var depolamas = db.Depolamas.Include(d => d.Denetleme).Include(d => d.User);
            return View(depolamas.ToList());
        }

        // GET: Depolamas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depolama depolama = db.Depolamas.Find(id);
            if (depolama == null)
            {
                return HttpNotFound();
            }
            return View(depolama);
        }

        // GET: Depolamas/Create
        public ActionResult Create()
        {
            ViewBag.DenetlemeID = new SelectList(db.Denetlemes, "DenetlemeID", "DenetlemeID");
            return View();
        }

        // POST: Depolamas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepolamaID,DenetlemeID,DepolamaYer,DepolamaTarih,DepolamaAcıklama,UserId")] Depolama depolama)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(Session["KisiId"].ToString());
                depolama.UserId = Id;
                db.Depolamas.Add(depolama);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DenetlemeID = new SelectList(db.Denetlemes, "DenetlemeID", "DenetlemeID", depolama.DenetlemeID);
            return View(depolama);
        }

        // GET: Depolamas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depolama depolama = db.Depolamas.Find(id);
            if (depolama == null)
            {
                return HttpNotFound();
            }
            ViewBag.DenetlemeID = new SelectList(db.Denetlemes, "DenetlemeID", "DenetlemeID", depolama.DenetlemeID);
            return View(depolama);
        }

        // POST: Depolamas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepolamaID,DenetlemeID,DepolamaYer,DepolamaTarih,DepolamaAcıklama,UserId")] Depolama depolama)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depolama).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DenetlemeID = new SelectList(db.Denetlemes, "DenetlemeID", "DenetlemeID", depolama.DenetlemeID);
            return View(depolama);
        }

        // GET: Depolamas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depolama depolama = db.Depolamas.Find(id);
            if (depolama == null)
            {
                return HttpNotFound();
            }
            return View(depolama);
        }

        // POST: Depolamas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Depolama depolama = db.Depolamas.Find(id);
            db.Depolamas.Remove(depolama);
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
