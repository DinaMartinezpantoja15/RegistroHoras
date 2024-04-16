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

namespace RegisroIngresos.Controllers
{
   public class AuthController : Controller
{
    private readonly BaseContext _context;

<<<<<<< HEAD
    public AuthController(BaseContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        // Aquí deberías llamar a un método que maneje la autenticación, por ejemplo:
        if (AuthenticateUser(model.Username, model.Password))
        {
            return RedirectToAction("Index", "Empleados"); // Redirecciona a la página principal después del inicio de sesión exitoso
        }
        else
        {
            ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
            return View(model);
        }
    }

    private bool AuthenticateUser(string username, string password)
    {

    var user = _context.Empleados.SingleOrDefault(u => u.Numero_documento == username && u.Contraseña == password);


    return user != null; // Retorna true si las credenciales son válidas, de lo contrario, retorna false
    }
}

    }

=======
    } }}

/*     [HttpPost]
    public async Task<IActionResult>Register(){
            var  Tipo_documento = await _context.Tipo_documento.ToListAsync();
            ViewBag.Tipo_documento=Tipo_documento;
            return View();
    }
}
} */
>>>>>>> cc79d850d9ba3d3134187f8436ec123ae78f6307
