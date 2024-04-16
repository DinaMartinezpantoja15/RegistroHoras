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
    public async Task<IActionResult>Register(){
            return View();

    }
}
}