using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetStoreDemo.Models;
using System.Net;

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
                new_pet.status = db.Status.Where(s => s.Id == new_pet.statusId).FirstOrDefault(); 
                var pet = new ApiPetsController().PostPet(new_pet); 
                return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
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
            return View(pet);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
                // TODO: Add delete logic here
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
