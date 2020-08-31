using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{
    public class PopulationDataAccessLayer
    {
        public static List<Expense> GetCityPopulationList()
        {
            var list = new List<Expense>();
            list.Add(new Expense { type = "expense", amount = 28000, catalouge = "asd", id=23213});
            list.Add(new Expense { type = "income", amount = 432432, catalouge = "aadsadsdasd", id = 2321233 });


            return list;

        }
    }
}