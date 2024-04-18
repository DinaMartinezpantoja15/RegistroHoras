using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegistroHoras.Models;
using RegistroHoras.Data;
using Microsoft.EntityFrameworkCore;

namespace RegisroIngresos.Controllers
{
    public class EmpleadosController : Controller{
        public readonly BaseContext _context;
        public EmpleadosController(BaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Index(){
            return View(await _context.Empleados.ToListAsync());
        }

        public IActionResult Historial(){
            return View();
        }
        

    }
}