using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStoreDemo.Controllers
{
    public class ValueTestController : Controller
    {
        // GET: ValueTest
        public ActionResult Index()
        {
            var tx = new ApiPetsController().GetPets();

            ViewBag.res = tx; 
               
            return View(tx);
        }
    }
}