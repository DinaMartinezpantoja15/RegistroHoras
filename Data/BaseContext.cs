using Microsoft.EntityFrameworkCore;
using RegisroIngresos.Models;
using RegistroHoras.Models;

namespace RegisroIngresos.Data{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Registro> Registro { get; set; }
    

        
}}