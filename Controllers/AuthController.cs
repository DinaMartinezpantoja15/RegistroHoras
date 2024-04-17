using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegisroIngresos.Models;
using RegisroIngresos.Data;
using Microsoft.EntityFrameworkCore;

namespace RegisroIngresos.Controllers
{
    public class AuthController : Controller{
        public readonly BaseContext _context;
        public AuthController(BaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Login(){
            return View();

    } 
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public IActionResult Create(Empleado e) {
            _context.Empleados.Add(e);
            //var pruebna =  new Tipo_documento(){Nombre = e.Tipo_documento.ToString()};
           // _context.Tipo_documento.Add(pruebna);
            _context.SaveChanges();
            return RedirectToAction("Login");

        }
    
    
    }}

