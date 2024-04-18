using Microsoft.EntityFrameworkCore;
using RegistroHoras.Models;


namespace RegistroHoras.Data{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Registro> Registro { get; set; }
    

        
}}