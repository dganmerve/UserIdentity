using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserIdentity.Identity;
using UserIdentity.Models;

namespace UserIdentity.Areas.Yetkili.Controllers
{
    public class AnasayfaController : Controller
    {
        private IdentityDataContext db = new IdentityDataContext();

        // GET: Yetkili/Anasayfa
        public ActionResult Index()
        {
            return View(db.Tercihs.ToList());
        }

        [Authorize]
        public ActionResult About()
        {
            return View();
        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,SoyAdi,Cinsiyet,Email,Telefon,Adres,ProjeAdi,ProjeAciklamasi,ProjeninNiteligi,Onay")] Tercih tercih)
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
                    entity.Onay = tercih.Onay;

                    db.SaveChanges();

                    TempData["Tercih"] = entity;
                    return RedirectToAction("Index");
                }
                //db.Entry(tercih).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(tercih);
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