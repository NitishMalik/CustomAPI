using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required, StringLength(5 , ErrorMessage ="Name should be atleast 5 characters long")]
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}
