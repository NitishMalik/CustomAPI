using CustomAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAPI.Data
{
    public class ShoppingDBContext : DbContext
    {
        public ShoppingDBContext(DbContextOptions<ShoppingDBContext> options):base(options)
        {

        }
        public DbSet<Shopping> Shopping { get; set; }
    }
}
