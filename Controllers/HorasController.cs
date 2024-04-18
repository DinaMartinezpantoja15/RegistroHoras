using Microsoft.AspNetCore.Mvc;
using RegistroHoras.Data;
using RegistroHoras.Models;
using RegistroHoras.Models;
using System;


namespace HorasController.Controllers
{
  public class HorasController : Controller
  {
    private readonly BaseContext _context;

    public HorasController(BaseContext context)
    {
      _context = context;
    }

    [HttpPost]
    public IActionResult MarcarHora()
    {
      // Obtener la hora y fecha actual del servidor
      var horaFechaActual = DateTime.Now;

      // Aquí puedes guardar la hora y fecha actual en tu base de datos, por ejemplo:
      var registro = new Registro
      {
        Hora_Entrada = horaFechaActual.TimeOfDay, // Guardar solo la hora
        Fecha_Entrada = new DateOnly(horaFechaActual.Year, horaFechaActual.Month, horaFechaActual.Day) // Convertir DateTime a DateOnly // Guardar solo la fecha
      };

      // Añadir el nuevo registro al contexto de la base de datos
      _context.Registro.Add(registro);

      // Guardar los cambios en la base de datos
      _context.SaveChanges();

      // Redirigir a la misma página o a donde prefieras
      return RedirectToAction("IndexSalida", "Empleados");
    }

    [HttpPost]
    public IActionResult MarcarSalida()
    {
      // Obtener la hora y fecha actual del servidor
      var horaFechaActual = DateTime.Now;

      // Aquí puedes guardar la hora y fecha actual en tu base de datos, por ejemplo:
      var registro = new Registro
      {
        Hora_Salida = horaFechaActual.TimeOfDay, // Guardar solo la hora
        Fecha_Salida = new DateOnly(horaFechaActual.Year, horaFechaActual.Month, horaFechaActual.Day) // Convertir DateTime a DateOnly // Guardar solo la fecha
      };

      // Añadir el nuevo registro al contexto de la base de datos
      _context.Registro.Add(registro);

      // Guardar los cambios en la base de datos
      _context.SaveChanges();

      // Redirigir a la misma página o a donde prefieras
      return RedirectToAction("IndexSalida", "Empleados");
    }
  }
}

