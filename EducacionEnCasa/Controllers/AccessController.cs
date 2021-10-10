using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionEnCasa.Controllers
{
    public class AccessController : Controller
    {
        private readonly AccessController _context;

       
        public IActionResult Login(string User,string Pass)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
            
        }
    }
}
