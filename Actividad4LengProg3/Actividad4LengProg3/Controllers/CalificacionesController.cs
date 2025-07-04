using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LengProg3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly AppDbContext _contex;

        public CalificacionesController(AppDbContext contex)
        {
            _contex = contex;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
