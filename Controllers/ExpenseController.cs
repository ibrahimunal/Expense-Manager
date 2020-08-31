using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forms.Models;
using Microsoft.AspNetCore.Http;

namespace Forms.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseContext _context;

        public ExpenseController(ExpenseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult PostMethod()
        {
            IEnumerable<Expense> expenseList = _context.ExpenseList.ToList();


            return Json(expenseList);
        }

        
        public IActionResult Chart()
        {
            return View();
            
        }

        private JsonResult Json(List<Expense> expensList, object allowGet)
        {
            throw new NotImplementedException();
        }

        // GET: Expense
        // GET: Expense
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseList.Where(x => x.UserId == HttpContext.Session.GetString("UserId")).ToListAsync());
        }

        // GET: Expense/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.ExpenseList.Where(x => x.UserId == HttpContext.Session.GetString("UserId"))
                .FirstOrDefaultAsync(m => m.id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expense/Create
        public  async  Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View( new Expense());
            }
            else {
                var expense = await _context.ExpenseList.FindAsync(id);
                if (expense == null)
                {
                    return NotFound();
                }
                return View(expense);
            }
            
        }



        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("id,type,amount,date,catalouge")] Expense expense)
        {

            if (ModelState.IsValid)
            {
                expense.UserId = HttpContext.Session.GetString("UserId");
                if (id == 0)
                {
                    expense.date = DateTime.Now;
                    
                    _context.Add(expense);
                    await _context.SaveChangesAsync();
                }
                else {    
                     try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                } 
            }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this,"_ViewAll",_context.ExpenseList.Where(x => x.UserId == HttpContext.Session.GetString("UserId")).ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", expense )});
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.ExpenseList
                .FirstOrDefaultAsync(m => m.id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.ExpenseList.FindAsync(id);
            _context.ExpenseList.Remove(expense);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.ExpenseList.Where(x => x.UserId == HttpContext.Session.GetString("UserId")).ToList()) });
        }

        private bool ExpenseExists(int id)
        {
            return _context.ExpenseList.Any(e => e.id == id);
        }
    }
}
