using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LengProg3.Controllers
{
    public class MateriasController : Controller
    {
        private readonly AppDbContext _context;
        public MateriasController(AppDbContext context) { 
        
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

    }
}
