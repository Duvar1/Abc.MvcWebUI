using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Identity;
using Abc.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;


        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total= i.Total, 
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres=i.Adres,
                    Sehir=i.Sehir,
                    Semt=i.Semt,
                    Mahalle=i.Mahalle,
                    PostaKodu=i.PostaKodu,  
                    OrderLines =i.OrderLines.Select(a=>new OrderLineModel()
                    { 
                        Price = a.Price,
                        ProductId = a.ProductId,
                        Image=a.Product.Image,
                        Quantity=a.Quantity,
                        ProductName=a.Product.Name
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }

        // GET: Account

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.UserName == username)
                .Select(i => new UserOrderModel()
            {
                Id = i.Id,
                OrderNumber=i.OrderNumber,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total  
            }).OrderByDescending(i=>i.OrderDate).ToList();   

            return View(orders);
        }

        public ActionResult Register()
        {    
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //kayıt işlemleri
                var user = new ApplicationUser();
                user.Email = model.Email;
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.UserName = model.UserName;

                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Register","Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası.");
                }

            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //kayıt işlemleri
                var user = UserManager.Find(model.UserName, model.Password);
                if(user != null)
                {
                    var authManager= HttpContext.GetOwinContext().Authentication;
                    var identityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;                                       
                    authManager.SignIn(authProperties,identityClaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }
    }
}