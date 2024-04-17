using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using RegistroHoras.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegisroIngresos.Models;
using RegisroIngresos.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using RegistroHoras.Models;

namespace RegistroHoras.Controllers
{
    public class HoraController : Controller
    {
        private readonly BaseContext _context;

        public HoraController(BaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ingresos = _context.Ingresos.ToList(); // Obtener todos los detalles de ingreso
            return View(ingresos);
        }

          [HttpPost]
        public async Task<IActionResult> MarcarIngreso()
        {
             // Obtener la hora y fecha actual
    DateTime horaActual = DateTime.Now;

    // Crear un nuevo registro en la base de datos
    Ingreso ingreso = new Ingreso
    {
        Hora_Ingreso = horaActual.TimeOfDay,
        Fecha_Ingreso = horaActual.Date
    };

    _context.Ingresos.Add(ingreso);
    await _context.SaveChangesAsync();

    // Retornar la vista "Index" del controlador "Empleados" con el último ingreso registrado
    var ultimoIngreso = await _context.Ingresos.OrderByDescending(i => i.Fecha_Ingreso).ThenByDescending(i => i.Hora_Ingreso).FirstOrDefaultAsync();
    return RedirectToAction("Index", "Empleados", new { horaIngreso = ultimoIngreso });
        }

    }
}
