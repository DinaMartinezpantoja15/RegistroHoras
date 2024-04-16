using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegisroIngresos.Models;
using RegisroIngresos.Data;
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

    }
}