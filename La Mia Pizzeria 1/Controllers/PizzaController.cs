using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
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
            foreach (Pizza post in listaDellePizze) {
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
            if (!ModelState.IsValid) {
                return View("NuovaPizza", formdata);
            }
            using PizzeriaContext db = new PizzeriaContext();
            db.Pizze.Add(formdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int id) {
            using PizzeriaContext db = new PizzeriaContext();
            Pizza? pizza = db.Pizze.Where(x => x.Id == id).FirstOrDefault();
                if (pizza == null) {
                    return NotFound("Pizza non presente");
                } else {
                    return View("ModificaPizza", pizza);
                }
        

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificaPizza(Pizza formdata) {
            if (!ModelState.IsValid) {
                return View("ModificaPizza", formdata);
            }
            using PizzeriaContext db = new PizzeriaContext();
            Pizza? ModificaPizza = db.Pizze.Where(x => x.Id == formdata.Id).FirstOrDefault();
            if (ModificaPizza != null) {
                ModificaPizza.Title = formdata.Title;
                ModificaPizza.Price = formdata.Price;
                ModificaPizza.Description = formdata.Description;
                ModificaPizza.Image= formdata.Image;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult EliminaPizza(int id) {
            using PizzeriaContext db = new PizzeriaContext();
            Pizza? EliminaPizza = db.Pizze.Where(x => x.Id == id).FirstOrDefault();
            if (EliminaPizza != null) {
                db.Remove(EliminaPizza);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
