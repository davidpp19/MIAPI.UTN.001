using Api.Consummer;
using MiAPI.UTN.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiApp.MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: EmpleadosController
        public ActionResult Index()
        {
            var empleados = Crud<Empleado>.ReadAll();
            return View(empleados);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud<Empleado>.ReadById(id.ToString());
            return View(datos);
        }

        private void LeerListaDatos()
        {
            var listaPersonas = Crud<Persona>.ReadAll();
            var listaCargos = Crud<Cargo>.ReadAll();

            var selectListPersonas = listaPersonas.Select(p =>
            new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Id} - {p.Apellido} - {p.Name}"
            }).OrderBy(i => i.Text);

            var selectListCargos = listaCargos.Select(c =>
            new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Id} - {c.Name}"
            }).OrderBy(i => i.Text);

            ViewData["ListaPersonas"] = selectListPersonas;
            ViewData["ListaCargos"] = selectListCargos;
        }
        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            LeerListaDatos();
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                var nuevoEmpleado = Crud<Empleado>.Create(empleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(empleado);
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(string id)
        {
            var datos = Crud<Empleado>.ReadById(id);
            LeerListaDatos();
            return View(datos);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado empleado)
        {
            try
            {
                Crud<Empleado>.Update(id.ToString(), empleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message; 
                return View(empleado);
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = Crud<Empleado>.ReadById(id);
            LeerListaDatos();
            return View(datos);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Empleado datos)
        {
            try
            {
                Crud<Empleado>.Delete(id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewData["Error"] = ex.Message;
                return View(datos);
            }
        }
    }
}
