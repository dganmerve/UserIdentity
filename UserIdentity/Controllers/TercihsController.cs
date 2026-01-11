using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserIdentity.Identity;
using UserIdentity.Models;

namespace UserIdentity.Controllers
{
    public class TercihsController : Controller
    {
        private IdentityDataContext db = new IdentityDataContext();
        private UserManager<ApplicationUser> userManager;

        public TercihsController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }

        // GET: Tercihs
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            return View(db.Tercihs.Where(x => x.UserId == UserId).ToList());
        }

        // GET: Tercihs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tercih tercih = db.Tercihs.Find(id);
            if (tercih == null)
            {
                return HttpNotFound();
            }
            return View(tercih);
        }

        // GET: Tercihs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tercihs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Adi,SoyAdi,Cinsiyet,Email,Telefon,Adres,ProjeAdi,ProjeAciklamasi,ProjeninNiteligi")] Tercih tercih)
        {
            var UserId = User.Identity.GetUserId();
            tercih.UserId = UserId;

            if (ModelState.IsValid)
            {
                tercih.Onay = false;
                db.Tercihs.Add(tercih);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tercih);
        }

        // GET: Tercihs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tercih tercih = db.Tercihs.Find(id);
            if (tercih == null)
            {
                return HttpNotFound();
            }
            return View(tercih);
        }

        // POST: Tercihs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,SoyAdi,Cinsiyet,Email,Telefon,Adres,ProjeAdi,ProjeAciklamasi,ProjeninNiteligi")] Tercih tercih)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Tercihs.Find(tercih.Id);
                if (entity != null)
                {
                    entity.Adi = tercih.Adi;
                    entity.SoyAdi = tercih.SoyAdi;
                    entity.Cinsiyet = tercih.Cinsiyet;
                    entity.Email = tercih.Email;
                    entity.Telefon = tercih.Telefon;
                    entity.Adres = tercih.Adres;
                    entity.ProjeAdi = tercih.ProjeAdi;
                    entity.ProjeAciklamasi = tercih.ProjeAciklamasi;
                    entity.ProjeninNiteligi = tercih.ProjeninNiteligi;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(tercih);
        }

        // GET: Tercihs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tercih tercih = db.Tercihs.Find(id);
            if (tercih == null)
            {
                return HttpNotFound();
            }
            return View(tercih);
        }

        // POST: Tercihs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tercih tercih = db.Tercihs.Find(id);
            db.Tercihs.Remove(tercih);
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
