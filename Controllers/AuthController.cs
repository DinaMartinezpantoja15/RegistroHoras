using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegistroHoras.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using RegistroHoras.Models;
using System.Web;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;



namespace RegistroHoras.Controllers
{
    public class AuthController : Controller
    {
        private readonly BaseContext _context;


    public AuthController(BaseContext context)
    {
        _context = context;
    }
        // se inicia el guardian//


    // se inicia formulario de crear un nuevo empleado


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (!string.IsNullOrEmpty(empleado.Contraseña))
            {
                empleado.Contraseña = CifrarContraseña(empleado.Contraseña);
            }

            _context.Empleados.Add(empleado);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        private string CifrarContraseña(string contraseña)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string contraseñaCifrada = Convert.ToBase64String(hashBytes);
            return contraseñaCifrada;
        }




    // se inicia el login con la autenticacion
    
    public async Task<IActionResult>Login(Empleado model)
{   
    var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Numero_documento == model.Numero_documento);


    // Verificar si se encontró un empleado con el nombre de usuario proporcionado
    if (empleado == null)
    {   TempData["message"] = "El documento no existe en la base de datos";
        /* ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos"); */
        return View("Login", model);
    }

    // Verificar si la contraseña proporcionada es correcta
    if (VerificarContraseña(model.Contraseña, empleado.Contraseña))
    {

        // Inicio de sesión exitoso, redireccionar a la página principal o a donde sea necesario
        HttpContext.Session.SetString("Nombre", empleado.Nombre );
        
        return RedirectToAction("Index", "Empleados");

    }
    else
    {
        // Contraseña incorrecta
        TempData["Message"] = "El documento o la contraseña no son correctos";
      /*   ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos"); */
        return View("Login", model);
    }
}

private bool VerificarContraseña(string contraseña, string contraseñaCifradaAlmacenada)
{
    byte[] hashBytesAlmacenado = Convert.FromBase64String(contraseñaCifradaAlmacenada);

    // Extraer la sal del hash almacenado
    byte[] salt = new byte[16];
    Array.Copy(hashBytesAlmacenado, 0, salt, 0, 16);

    // Calcular el hash de la contraseña proporcionada utilizando la misma sal
    var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, 10000);
    byte[] hash = pbkdf2.GetBytes(20);

    // Comparar los hashes
    for (int i = 0; i < 20; i++)
    {
        if (hashBytesAlmacenado[i + 16] != hash[i])
        {
            return false; // Las contraseñas no coinciden
        }
    }

    return true; // Las contraseñas coinciden
}

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
     
      HttpContext.Session.Clear();
        return RedirectToAction("Login", "Auth");
    }
    
    


    





    
}


}



