using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserIdentity.Identity;
using UserIdentity.Models;

namespace UserIdentity.Controllers
{

    public class homeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //public ActionResult BasvuruEkle()
        //{

        //    return View();
        //}
        //[HttpPost]

        //public ActionResult BasvuruEkle(Tercih entity)
        //{
        //    IdentityDataContext context = new IdentityDataContext();
        //    //Basvuru BasvuruKayit = new Basvuru();
        //    //BasvuruKayit.Cinsiyet =false;
        //    //BasvuruKayit.ProjeninNiteligi = false;
        //    //BasvuruKayit.Id = 250;
        //    Tercih t = new Tercih();
        //    //t.Cinsiyet = true;
        //    //t.ProjeninNiteligi = false;
        //    context.Tercihs.Add(entity);
        //    context.SaveChanges();
        //    return View();
        //}
        [Authorize]
        public ActionResult About()
        {
            return View();
        }
    }
}
        // GET: home 

//        public ActionResult Index()
//        {
//            return View();
//        }
//        [Authorize]
//        public ActionResult About()
//        {
//            return View();
//        }
//        [HttpGet]
//        public ActionResult BasvuruEkle(Basvuru entity)
//        {
//            IdentityDataContext context = new IdentityDataContext();
//            Basvuru BasvuruKayit = new Basvuru();
//            context.Basvurus.Add(entity);
//            context.SaveChanges();

//            return View();
//        }


//    }
//}
