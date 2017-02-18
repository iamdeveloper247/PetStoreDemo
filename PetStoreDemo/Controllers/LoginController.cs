using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetStoreDemo.Util;
using PetStoreDemo.Models;  

namespace PetStoreDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        PetStoreDemoContext db = new PetStoreDemoContext(); 
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [BasicAuthentication]
        public ActionResult Index(FormCollection collection)
        {
            string username = Request.Form["username"]; 
            string password = Request.Form["password"];
            string errmsg = null; 

            if(EmployeeSecurity.login(username, password))
            {
                User usr = db.Users.Where(u => u.UserName == username).FirstOrDefault();
                
                System.Web.HttpContext.Current.Session.Add("user", username);
                System.Web.HttpContext.Current.Session.Add("fullname", usr.FullName);
                ViewBag.errmsg = errmsg;
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                errmsg = "Username or Password Incorrect";
                ViewBag.errmsg = errmsg;
                return View();
            }
            
        }

        public ActionResult logout()
        {
            //System.Web.HttpContext.Current.Session.Remove("user");
            Session["user"] = null;
            return RedirectToAction("Index", "Login");
        }

     
        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
      
    }
}
