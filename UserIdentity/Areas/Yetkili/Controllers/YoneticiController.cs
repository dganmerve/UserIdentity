using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserIdentity.Identity;

namespace UserIdentity.Areas.Yetkili.Controllers
{
    [Authorize(Roles = "Admin")]


    public class YoneticiController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}




       
