using Api.Consummer;
using MiAPI.UTN.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiApp.MVC.Controllers
{
    public class CargosController : Controller
    {
        // GET: CargosController
        public ActionResult Index()
        {
            var cargos = Crud<Cargo>.ReadAll();
            return View(cargos);
        }

        // GET: CargosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud<Cargo>.ReadById(id.ToString());
            return View(datos);
        }

        // GET: CargosController/Create
        public ActionResult Create()
        {
            //Devuelve vista Sin datos, ya que el formulario se llenará con los datos que el usuario ingrese
            return View();
        }

        // POST: CargosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cargo data)
        {
            try
            {
                var nuevoCargo = Crud<Cargo>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View(data);
            }
        }
        

        // GET: CargosController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud<Cargo>.ReadById(id.ToString());
            ViewBag.ListaEmpleados = Crud<Empleado>
                .ReadAll()
                .Where(e => e.CargoId == id)
                .ToList();
            return View(datos);
        }

        // POST: CargosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cargo datos)
        {
            try
            {
                Crud<Cargo>.Update(id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View(datos);
            }
        }

        // GET: CargosController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = Crud<Cargo>.ReadById(id);
            return View(datos);
        }

        // POST: CargosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Cargo datos)
        {
            try
            {
                Crud<Cargo>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                {
                    ViewData["Error"] = ex.Message + ", :(";
                    return View(datos);
                }
            }
        }
    }
}
