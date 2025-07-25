using GestionTareasSoftware.Api.Models;
using GestionTareasSoftware.CRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionTareasSoftware.Web.Controllers
{
    public class UsuarioProyectosController : Controller
    {
        // GET: UsuarioProyectosController
        public ActionResult Index()
        {
            var data = Crud<UsuarioProyecto>.GetAll();
            return View(data);
        }

        // GET: UsuarioProyectosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<UsuarioProyecto>.GetById(id);
            return View(data);
        }

        // GET: UsuarioProyectosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioProyectosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioProyecto data)
        {
            try
            {
                Crud<UsuarioProyecto>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioProyectosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<UsuarioProyecto>.GetById(id);
            return View(data);
        }

        // POST: UsuarioProyectosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,UsuarioProyecto data)
        {
            try
            {
                Crud<UsuarioProyecto>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioProyectosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<UsuarioProyecto>.GetById(id);
            return View(data);
        }

        // POST: UsuarioProyectosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioProyecto data)
        {
            try
            {
                Crud<UsuarioProyecto>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
