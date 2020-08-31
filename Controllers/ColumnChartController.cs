
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forms.Controllers
{
    public class ColumnChartController : Controller
    {
        private readonly ExpenseContext _context;

        public ColumnChartController(ExpenseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
    

        [HttpGet]
        public JsonResult PopulationChart() {

         
            var expenseList = _context.ExpenseList.Where(x=> x.UserId == HttpContext.Session.GetString("UserId")).ToList();
            var populationList = PopulationDataAccessLayer.GetCityPopulationList();
            return Json( expenseList);
        }
    }
}
