using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        public static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid) //Verificar si los datos del modelo que se envían son válidos.
            {
                estudiantes.Add(estudiante);
                TempData["Mensaje"] = "Estudiante registrado exitosamente.";
                return RedirectToAction("Lista"); //Redirigir al usuario a la accion Lista

            }

            return View();
        }


        public IActionResult Lista()
        {

            return View(estudiantes);

        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
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
                EstudianteViewModel original = estudiantes.FirstOrDefault(e => e.Matricula.Equals(estudiante.Matricula));

                if (original == null)
                {
                    TempData["Mensaje"] = "No existe el usuario indicado";
                    return RedirectToAction("Lista");
                }

                // Actualiza los campos necesarios
                original.NombreCompleto = estudiante.NombreCompleto;
                original.Carrera = estudiante.Carrera;
                original.CorreoInstitucional = estudiante.CorreoInstitucional;
                original.Telefono = estudiante.Telefono;
                original.FechaNacimiento = estudiante.FechaNacimiento;
                original.Genero = estudiante.Genero;
                original.Turno = estudiante.Turno;
                original.TipoIngreso = estudiante.TipoIngreso;
                original.PorcentajeBeca = estudiante.PorcentajeBeca;
                //original.TerminosYCondiciones = estudiante.TerminosYCondiciones;

                TempData["Mensaje"] = "Actualizaciones realizadas correctamente";
                return RedirectToAction("Lista");
            }

            return View(estudiante);
        }



        public IActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
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
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                TempData["Mensaje"] = "Estudiante sustraido correctamente";
                estudiantes.Remove(estudiante);
            }

            return RedirectToAction("Lista");
        }

    }
}
