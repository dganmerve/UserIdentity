 using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using UserIdentity.Identity;
using UserIdentity.Models;

namespace UserIdentity.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AccountController()

        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);

            userManager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                 RequiredLength=7,
                  RequireLowercase=true,
                    RequireUppercase=true,
                     RequireNonLetterOrDigit=true
            };
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames=false,
            };
        }

        // GET: Account
        
        public ActionResult Index()
            {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return View("Error", new string[] { "Erişim izni yok" });
            //}
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model,string returnUrl)
        {
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return View("Error", new string[] { "Erişim izni yok" });
            //}

            if (ModelState.IsValid)
            { 
                var user = userManager.Find(model.UserName, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Yanlış kullanıcı adı veya parola");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    var autProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };
                    authManager.SignOut();
                    authManager.SignIn(autProperties, identity);

                    return Redirect(string.IsNullOrEmpty(returnUrl) ? "/":returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Register model)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add("beyzaatesli60@gmail.com");
            mailim.From = new MailAddress("beyzaatesli60@gmail.com");
            mailim.Subject = "Üye olduğunuz , hoşgeldiniz.";
            mailim.Body = "Kaydınız başarılıdır.";
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("beyzaatesli60@gmail.com", "388322_beyzo");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;


            try
            {
                smtp.Send(mailim);
                TempData["Message"] = "Mesajınız iletilmiştir";

            }
            catch(Exception ex)
            {
                TempData["Message"] = "Mesaj gönderilemedi" + ex.Message;
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;

                var result = userManager.Create(user, model.Password);

                if(result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Login");
        }
    }
}