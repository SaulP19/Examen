using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaExamen.ENTITIES;

namespace PruebaExamen.Context
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options)
        {

        }

        public DbSet<PRODUCTOS> PRODUCTOS { get; set; }
    }
}
