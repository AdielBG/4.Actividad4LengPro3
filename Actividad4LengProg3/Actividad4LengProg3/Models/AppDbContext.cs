using Microsoft.EntityFrameworkCore;
namespace Actividad4LengProg3.Models
{
    public class AppDbContext : DbContext
    //la clase base que maneja la conexión con la base de datos y el mapeo de modelos a tablas.
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        //permite inyectar opciones de configuración del contexto, como la cadena de conexión y el proveedor de base de datos

        public DbSet<EstudianteViewModel> Estudiantes { get; set; }
        public DbSet<MateriaViewModel> Materias { get; set; }
        public DbSet<CalificacionViewModel> Calificaciones { get; set; }

    }
}
