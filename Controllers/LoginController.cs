using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.Models;

namespace Forms.Controllers
{
    public class LoginController : Controller
    {
      

        public ViewResult UserLogin(User user)
        {

            return View();
        }
    }
}
