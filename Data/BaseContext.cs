using Microsoft.EntityFrameworkCore;
using RegisroIngresos.Models;

namespace RegisroIngresos.Data{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tipo_documento> Tipo_documento { get; set; }
    }
}