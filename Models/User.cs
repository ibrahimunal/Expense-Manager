using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{
    public class User
    {
       
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        [Key]
        public string UserPassword { get; set; }
        public string checkPassword { get; set; }

        public bool isVerified { get; set; }
    }
}
