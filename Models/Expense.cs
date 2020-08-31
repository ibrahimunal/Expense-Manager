using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{
    public class Expense
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string type { get; set; } // income or outcome
        [Column(TypeName = "nvarchar(20)")]
        public String UserId { get; set; }
        [DisplayName("Amount")]
        [Required]
        public int amount { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime date { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        [Required]
        [DisplayName("Catalogue")]
        public  string catalouge { get; set; } 
    }
}
