using Forms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{
    public class ExpenseContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=IBRAHIM; database=RegisteredUsers; integrated security=true");
        }
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options) { 
        }
        

        
        public DbSet<Expense> ExpenseList { get; set; }
        public object UserContext { get; internal set; }
    }
}
