using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers
{
    
    public class FormController : Controller
    {
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Register(User user)
        {
            
            using (var context = new Context()) {

                context.UserContext.Add(user);
                context.SaveChanges();
            
            }
                return View(user);
        }
   
    }
}
