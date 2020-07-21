using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAPI.Models
{
    public class Shopping
    {
        [Required]
        public int ShoppingId { get; set; }

        [Required, StringLength(5, ErrorMessage ="Item name should be 5 characters long")]
        public string ItemName { get; set; }
    }
}
