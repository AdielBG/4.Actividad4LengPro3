using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }//Inyecta el contexto de base de datos para usarlo en todo el controlador.

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges(); //  Muy importante
                TempData["Mensaje"] = "Estudiante registrado exitosamente.";
                return RedirectToAction("Lista");
            }
            return View(estudiante);
        }


        public IActionResult Lista()
        {

            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);

        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                TempData["Mensaje"] = "No existe el usuario indicado";
                return RedirectToAction("Lista");
            }

            return View(estudiante);
        }



        [HttpPost]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                var original = _context.Estudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);

                if (original == null)
                {
                    TempData["Mensaje"] = "No existe el usuario indicado";
                    return RedirectToAction("Lista");
                }

                // Actualizar campos
                original.NombreCompleto = estudiante.NombreCompleto;
                original.Carrera = estudiante.Carrera;
                original.CorreoInstitucional = estudiante.CorreoInstitucional;
                original.Telefono = estudiante.Telefono;
                original.FechaNacimiento = estudiante.FechaNacimiento;
                original.Genero = estudiante.Genero;
                original.Turno = estudiante.Turno;
                original.TipoIngreso = estudiante.TipoIngreso;
                original.PorcentajeBeca = estudiante.PorcentajeBeca;
                original.EstaBecado = estudiante.EstaBecado;
                original.TerminosYCondiciones = estudiante.TerminosYCondiciones;

                _context.Update(original); //  Agregado
                _context.SaveChanges();    //  Agregado

                TempData["Mensaje"] = "Actualizaciones realizadas correctamente";
                return RedirectToAction("Lista");
            }

            return View(estudiante);
        }



        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                TempData["Mensaje"] = "No existe el usuario indicado";
                return RedirectToAction("Lista");
            }
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges(); //  Necesario
                TempData["Mensaje"] = "Estudiante eliminado correctamente";
            }

            return RedirectToAction("Lista");
        }

    }
}
