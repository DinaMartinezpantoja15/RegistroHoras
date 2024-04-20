using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegistroHoras.Data;
using RegistroHoras.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;



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
    public async Task<IActionResult> MarcarHora()
    {
      try
      {
        // Obtener la hora y fecha actual del servidor
        var horaFechaActual = DateTime.Now;

        // Obtener el ID del empleado almacenado en la sesión
        var empleadoId = HttpContext.Session.GetInt32("Id");


        var registro = new Registro
        {
          Hora_Entrada = horaFechaActual.TimeOfDay,
          Fecha_Entrada = new DateOnly(horaFechaActual.Year, horaFechaActual.Month, horaFechaActual.Day),
          EmpleadoId = empleadoId.Value
        };

        // Añadir el nuevo registro al contexto de la base de datos
        _context.Registro.Add(registro);
        await _context.SaveChangesAsync();

        TempData["MessageSuccess"] = "Se ha registrado tu entrada correctamente";
        /* }
        }
       else
       {
         // No se encontró un ID de empleado válido en la sesión, mostrar un mensaje de error o redirigir a alguna página de error
         TempData["MessageError"] = "No se encontró un empleado válido en la sesión";
       } */
      }
      catch (Exception ex)
      {
        // Manejar errores (puedes enviar un mensaje a Slack u otro sistema de notificación)
        TempData["MessageError"] = "Ocurrió un error al procesar tu solicitud";
        // Loguear el error para futura revisión
        Console.WriteLine($"Error al marcar la hora de entrada: {ex.Message}");
      }

      return RedirectToAction("IndexSalida", "Empleados");
    }



    [HttpPost]
    public async Task<IActionResult> MarcarSalida()
    {
      try
      {
        // Obtener el registro correspondiente al empleado que está intentando hacer el checkout
        var registro = await _context.Registro.FirstOrDefaultAsync(r => r.EmpleadoId == HttpContext.Session.GetInt32("Id") && r.Hora_Salida == null);

        // Verificar si se encontró un registro válido
        if (registro != null)
        {
          // Obtener la hora y fecha actual del servidor
          var horaFechaActual = DateTime.Now;

          // Actualizar la propiedad Hora_Salida con la hora actual
          registro.Hora_Salida = horaFechaActual.TimeOfDay;

          // Actualizar la propiedad Fecha_Salida con la fecha actual
          registro.Fecha_Salida = new DateOnly(horaFechaActual.Year, horaFechaActual.Month, horaFechaActual.Day);

          // Guardar los cambios en la base de datos
          await _context.SaveChangesAsync();

          TempData["MessageSuccess"] = "Se ha registrado tu salida correctamente";
        }
        else
        {
          TempData["MessageError"] = "No se encontró un registro de entrada válido para tu usuario";
        }
      }
      catch (System.Exception ex)
      {
        // Manejar errores (puedes enviar un mensaje a Slack u otro sistema de notificación)
        TempData["MessageError"] = "Ocurrió un error al procesar tu solicitud";
        // Loguear el error para futura revisión
        Console.WriteLine($"Error al marcar la salida: {ex.Message}");
      }

      return RedirectToAction("Index", "Empleados");
    }

  }
}

