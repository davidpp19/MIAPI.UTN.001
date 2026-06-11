using Api.Consummer;
using MiAPI.UTN.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiApp.MVC.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            var personas = Crud<Persona>.ReadAll();
            return View(personas);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud<Persona>.ReadById(id.ToString());
            return View(datos);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona data)
        {
            try
            {
                var nuevaPersona = Crud<Persona>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud<Persona>.ReadById(id.ToString());
            return View(datos);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Persona persona)
        {
            try
            {
                Crud<Persona>.Update(id.ToString(), persona);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = Crud<Persona>.ReadById(id);
            return View(datos);
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Persona persona)
        {
            try
            {
                Crud<Persona>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewData["Message"] = ex.Message;
                return View(persona);
            }
        }
    }
}
