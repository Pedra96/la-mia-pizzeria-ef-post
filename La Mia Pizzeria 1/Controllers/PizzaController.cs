using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata.Ecma335;

namespace La_Mia_Pizzeria_1.Controllers {
    public class PizzaController : Controller {

        public IActionResult Index() {
          using PizzeriaContext db = new PizzeriaContext();
            List<Pizza> listaDellePizze = db.Pizze.ToList();          

            return View("Index", listaDellePizze);
        }
        public IActionResult Details(int id) {
            using PizzeriaContext db = new PizzeriaContext();
            List<Pizza> listaDellePizze = db.Pizze.ToList();

            foreach (Pizza post in  listaDellePizze) {
                if (post.Id == id) {
                    return View(post);
                }
            }

            return NotFound("Il post con l'id cercato non esiste!");
        }

        [HttpGet]
        public IActionResult NuovaPizza() {
            return View("NuovaPizza");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuovaPizza(Pizza formdata) {
            if(!ModelState.IsValid) {
                return View("NuovaPizza", formdata);
            }
            using PizzeriaContext db = new PizzeriaContext();
            db.Pizze.Add(formdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
