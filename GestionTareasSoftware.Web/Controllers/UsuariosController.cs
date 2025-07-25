using GestionTareasSoftware.Api.Models;
using GestionTareasSoftware.CRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionTareasSoftware.web.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: UsuariosController
        public ActionResult Index()
        {
            var data = Crud<Usuario>.GetAll();
            return View(data);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Usuario>.GetById(id);
            return View(data);
        }
        private List<SelectListItem> GetProyectos()
        {
            var Tareas = Crud<Proyecto>.GetAll();
            return Tareas.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = $"{a.NombreProyecto} {a.Descripcion}{a.Descripcion}"
            }).ToList();
        }
        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario data)
        {
            try
            {
                Crud<Usuario>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Usuario>.GetById(id);
            return View(data);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario data)
        {
            try
            {
                Crud<Usuario>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Usuario>.GetById(id);
            return View(data);
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario data)
        {
            try
            {
                Crud<Usuario>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
