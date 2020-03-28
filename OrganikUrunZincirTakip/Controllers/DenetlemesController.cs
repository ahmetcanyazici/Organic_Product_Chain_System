using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OrganikUrunZincirTakip.Filter;
using OrganikUrunZincirTakip.Models;

namespace OrganikUrunZincirTakip.Controllers
{
    [DenetleyiciAuth]
    public class DenetlemesController : Controller
    {
        private OrganikUrunDBContext db = new OrganikUrunDBContext();

        // GET: Denetlemes
        public ActionResult Index()
        {
            var denetlemes = db.Denetlemes.Include(d => d.User);
            return View(denetlemes.ToList());
        }

        // GET: Denetlemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denetleme denetleme = db.Denetlemes.Find(id);
            if (denetleme == null)
            {
                return HttpNotFound();
            }
            return View(denetleme);
        }

        // GET: Denetlemes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Denetlemes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DenetlemeID,SertifikaID,DenetlemeAcıklama,UserId")] Denetleme denetleme)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(Session["KisiId"].ToString());
                denetleme.UserId = Id;
                db.Denetlemes.Add(denetleme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(denetleme);
        }

        // GET: Denetlemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denetleme denetleme = db.Denetlemes.Find(id);
            if (denetleme == null)
            {
                return HttpNotFound();
            }
            return View(denetleme);
        }

        // POST: Denetlemes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DenetlemeID,SertifikaID,DenetlemeAcıklama,UserId")] Denetleme denetleme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(denetleme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(denetleme);
        }

        // GET: Denetlemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denetleme denetleme = db.Denetlemes.Find(id);
            if (denetleme == null)
            {
                return HttpNotFound();
            }
            return View(denetleme);
        }

        // POST: Denetlemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Denetleme denetleme = db.Denetlemes.Find(id);
            db.Denetlemes.Remove(denetleme);
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
