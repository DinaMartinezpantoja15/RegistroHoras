using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegistroHoras.Models;
using RegistroHoras.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RegisroIngresos.Controllers
{
    public class EmpleadosController : Controller
    {
        public readonly BaseContext _context;
        public EmpleadosController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>Index()
        {
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
            if (ViewBag.Nombre==null){
                return RedirectToAction("Login","Auth");
            }
            
                
                
                return View(await _context.Empleados.ToListAsync());

            }

            
            

        /*   public async Task<IActionResult> Index()
       {
           // Obtener la lista de registros desde la base de datos
           var registros = await _context.Registros.ToListAsync();

           // Pasar la lista de registros como modelo a la vista
           return View(registros);
       } */

        public async Task<IActionResult> Historial()
        {
            return View(await _context.Registro.ToListAsync());
        }


    }
}