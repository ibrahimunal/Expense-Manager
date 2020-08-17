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
                
                if (user.UserPassword == user.checkPassword)
                {
                    ViewBag.message = "You succesfully registered please check your e-mail for varification link";
                    user.isVerified = true;
                    context.UserContext.Add(user);
                    context.SaveChanges();
                    return View(user);
                }
                else
                {
                    ViewBag.message = "Opss.. something went wrong. Your passwords dont match please check them";
                    return View(user);
                }
                

            }
                
        }
   
    }
}
