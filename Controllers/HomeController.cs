﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forms.Models;

namespace Forms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        Context c = new Context();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userList = c.UserContext.ToList();
            return View(userList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Expense()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
