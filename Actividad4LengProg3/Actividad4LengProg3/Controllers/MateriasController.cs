using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LengProg3.Controllers
{
    public class MateriasController : Controller
    {
        private readonly AppDbContext _context;
        public MateriasController(AppDbContext context)
        {

            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(MateriaViewModel materia)
        {
            if (ModelState.IsValid)
            {
                _context.Materias.Add(materia);
                _context.SaveChanges();
                TempData["Mensaje"] = "Materia registrada exitosamente.";
                return RedirectToAction("Lista");
            }
            return View(materia);
        }

        public IActionResult Lista()
        {
            var materias = _context.Materias.ToList();
            return View(materias);
        }

        [HttpGet]
        public IActionResult Editar(string codigo)
        {
            var materia = _context.Materias.FirstOrDefault(m => m.Codigo == codigo);
            if (materia == null)
            {
                TempData["Mensaje"] = "No existe la materia indicado";
                return RedirectToAction("Lista");
            }

            return View(materia);
        }



        [HttpPost]
        public IActionResult Editar(MateriaViewModel materia)
        {
            if (ModelState.IsValid)
            {
                var original = _context.Materias.FirstOrDefault(m => m.Codigo == materia.Codigo);

                if (original == null)
                {
                    TempData["Mensaje"] = "No existe la materia indicado";
                    return RedirectToAction("Lista");
                }

                // Actualizar campos
                original.Codigo = materia.Codigo;
                original.Nombre = materia.Nombre;
                original.Creditos = materia.Creditos;
                original.Carrera = materia.Carrera;

                _context.Update(original);
                _context.SaveChanges();

                TempData["Mensaje"] = "Actualizaciones realizadas correctamente";
                return RedirectToAction("Lista");
            }

            return View(materia);
        }



        //    public IActionResult Eliminar(string matricula)
        //    {
        //        var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
        //        if (estudiante == null)
        //        {
        //            TempData["Mensaje"] = "No existe el usuario indicado";
        //            return RedirectToAction("Lista");
        //        }
        //        return View(estudiante);
        //    }

        //    [HttpPost]
        //    public IActionResult EliminarConfirmado(string matricula)
        //    {
        //        var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
        //        if (estudiante != null)
        //        {
        //            _context.Estudiantes.Remove(estudiante);
        //            _context.SaveChanges(); //  Necesario
        //            TempData["Mensaje"] = "Estudiante eliminado correctamente";
        //        }

        //        return RedirectToAction("Lista");
        //    }


        //}
    }
}
