using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetStoreDemo.Models;
using System.Net;
using System.Web.UI.WebControls;
using System.IO;

namespace PetStoreDemo.Controllers
{
    public class PetsController : Controller
    {
        PetStoreDemoContext db = new PetStoreDemoContext();
        // GET: Pets
        public ActionResult Index()
        {
            var pets = new ApiPetsController().GetPets();

            ViewBag.pets = pets;
            ViewBag.status = db.Status.ToList(); 

            return View(pets);
        }

        // GET: Pets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Category")] Pet new_pet)
        {
            try
            {
                new_pet.statusId = 1;
                var pet = new ApiPetsController().PostPet(new_pet);

                return RedirectToAction("Index"); 
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.status = db.Status.ToList(); 
            
            return View(pet);
        }

        // POST: Pets/Edit/5 [Bind(Include = "Id,Name,Category,statusId,status")] Pet edit_pet
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Pet edit_pet = new Pet();
                edit_pet.Id = int.Parse(collection["Id"]); 
                edit_pet.Name = (collection["Name"]);
                edit_pet.Category = (collection["Category"]);
                edit_pet.statusId = int.Parse(collection["statusId"]);
                // TODO: Add update logic here
                var edited_pet = new ApiPetsController().PutPet(id, edit_pet);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                string stack = e.StackTrace;
                string src = e.Source;
                string msg = e.Message;
                string s = e.InnerException.ToString();
                return RedirectToAction("Index");
            }
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            } 
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var pet = new ApiPetsController().DeletePet(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
    }
}
