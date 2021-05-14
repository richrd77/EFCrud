using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCrud
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions op) : base(op)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
