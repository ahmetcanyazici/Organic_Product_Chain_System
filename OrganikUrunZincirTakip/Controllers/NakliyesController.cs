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
    [NakliyeciAuth]
    public class NakliyesController : Controller
    {
        private OrganikUrunDBContext db = new OrganikUrunDBContext();

        // GET: Nakliyes
        public ActionResult Index()
        {
            var nakliyes = db.Nakliyes.Include(n => n.Depolama).Include(n => n.User);
            return View(nakliyes.ToList());
        }

        // GET: Nakliyes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nakliye nakliye = db.Nakliyes.Find(id);
            if (nakliye == null)
            {
                return HttpNotFound();
            }
            return View(nakliye);
        }

        // GET: Nakliyes/Create
        public ActionResult Create()
        {
            ViewBag.DepolamaID = new SelectList(db.Depolamas, "DepolamaID", "DepolamaID");
            return View();
        }

        // POST: Nakliyes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NakliyeID,DepolamaID,TeslimalimYer,TeslimedimYer,Tarih,NakliyeAcıklama,UserId")] Nakliye nakliye)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(Session["KisiId"].ToString());
                nakliye.UserId = Id;
                db.Nakliyes.Add(nakliye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepolamaID = new SelectList(db.Depolamas, "DepolamaID", "DepolamaID", nakliye.DepolamaID);
            return View(nakliye);
        }

        // GET: Nakliyes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nakliye nakliye = db.Nakliyes.Find(id);
            if (nakliye == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepolamaID = new SelectList(db.Depolamas, "DepolamaID", "DepolamaID", nakliye.DepolamaID);
            return View(nakliye);
        }

        // POST: Nakliyes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NakliyeID,DepolamaID,TeslimalimYer,TeslimedimYer,Tarih,NakliyeAcıklama,UserId")] Nakliye nakliye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nakliye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepolamaID = new SelectList(db.Depolamas, "DepolamaID", "DepolamaID", nakliye.DepolamaID);
            return View(nakliye);
        }

        // GET: Nakliyes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nakliye nakliye = db.Nakliyes.Find(id);
            if (nakliye == null)
            {
                return HttpNotFound();
            }
            return View(nakliye);
        }

        // POST: Nakliyes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nakliye nakliye = db.Nakliyes.Find(id);
            db.Nakliyes.Remove(nakliye);
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
