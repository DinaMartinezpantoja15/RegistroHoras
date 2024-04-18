using Microsoft.EntityFrameworkCore;
using RegistroHoras.Models;


namespace RegistroHoras.Data{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Registro> Registros { get; set; }
    
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las entidades y relaciones...
        }
        
}}