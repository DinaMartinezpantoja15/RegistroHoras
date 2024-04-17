using Microsoft.EntityFrameworkCore;
using RegisroIngresos.Models;
using RegistroHoras.Models;

namespace RegisroIngresos.Data{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Registro> Registro { get; set; }
    

        
}}