using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LengProg3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly AppDbContext _context;

        public CalificacionesController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(CalificacionViewModel calificacion)
        {
            if (!ModelState.IsValid)
            {
                // Crear un mensaje con todos los errores
                var errores = new List<string>();
                foreach (var modelError in ModelState)
                {
                    var key = modelError.Key;
                    var errors = modelError.Value.Errors;
                    foreach (var error in errors)
                    {
                        errores.Add($"Campo '{key}': {error.ErrorMessage}");
                    }
                }

                // Mostrar errores en TempData para que aparezcan en la vista
                TempData["Errores"] = string.Join(" | ", errores);
                TempData["Mensaje"] = "Error de validación. Revise los campos.";
                return View("Index", calificacion);
            }

            try
            {
                _context.Calificaciones.Add(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Calificación registrada exitosamente.";
                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = $"Error al guardar: {ex.Message}";
                return View("Index", calificacion);
            }

            //if (ModelState.IsValid)
            //{
            //    _context.Calificaciones.Add(calificacion);
            //    _context.SaveChanges();
            //    TempData["Mensaje"] = "Calificación registrada exitosamente.";
            //    return RedirectToAction("Lista");
            //}
            //else
            //{
            //    TempData["Mensaje"] = "Error de registro.";
            //    //return RedirectToAction("Lista");
            //}
            //    return View("Index", calificacion);
        }

        public IActionResult Lista()
        {
            var calificaciones = _context.Calificaciones.ToList();
            return View(calificaciones);
        }

    }
}
