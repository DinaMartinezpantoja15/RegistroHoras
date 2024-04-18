using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegistroHoras.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using RegistroHoras.Models;

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
            ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos");
            return View("Login",model);
        }  
    }

    private bool AuthenticateUser(string username, string password)
    {

    var user = _context.Empleados.SingleOrDefault(u => u.Numero_documento == username && u.Contraseña == password);


    return user != null; // Retorna true si las credenciales son válidas, de lo contrario, retorna false
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        // Aquí puedes realizar cualquier limpieza necesaria para cerrar la sesión del usuario.
        // Por ejemplo, puedes eliminar cualquier cookie de autenticación o información de sesión.
        // await HttpContext.SignOutAsync();
        // Después de cerrar sesión, puedes redirigir al usuario a la página de inicio de sesión u otra página de tu elección.
        return RedirectToAction("Login", "Auth");
    }



        // se inicia formulario de crear un nuevo empleado


     public IActionResult Create(){
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


    

    
}}



