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
    }
}
