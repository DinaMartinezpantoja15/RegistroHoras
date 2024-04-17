using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using RegistroHoras.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegisroIngresos.Models;
using RegisroIngresos.Data;
using Microsoft.EntityFrameworkCore;
using System;
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

        [HttpPost]
        public async Task<IActionResult> MarcarHora()
        {
            // Obtener la hora y fecha actual
            DateTime horaActual = DateTime.Now;

            // Crear un nuevo registro en la base de datos
            HoraModel hora = new HoraModel
            {
                FechaHora = horaActual
            };

           /*  _context.Empleados.Add(hora); */
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Empleados"); // Redireccionar a la página principal después de marcar la hora
        }
    }
}
