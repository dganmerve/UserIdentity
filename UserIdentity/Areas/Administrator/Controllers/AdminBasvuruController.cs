using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserIdentity.Identity;
using UserIdentity.Models;

namespace UserIdentity.Areas.Administrator.Controllers
{
    public class AdminBasvuruController : Controller
    {
        private IdentityDataContext db = new IdentityDataContext();

        // GET: BasvuruModels
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            return View(db.Basvurular.Where(i => i.UserId == userId).ToList());
        }// GET: BasvuruModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasvuruModel basvuruModel = db.Basvurular.Find(id);
            if (basvuruModel == null)
            {
                return HttpNotFound();
            }
            return View(basvuruModel);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasvuruModel basvuruModel = db.Basvurular.Find(id);
            if (basvuruModel == null)
            {
                return HttpNotFound();
            }
            return View(basvuruModel);
        }

        // POST: BasvuruModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Isim,SoyIsim,Mail,Telefon,Adres,ProjeAdi,Aciklama,Onay")] BasvuruModel basvuruModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basvuruModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basvuruModel);
        }
    }
}