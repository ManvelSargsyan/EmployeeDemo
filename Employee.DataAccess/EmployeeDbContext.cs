using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Employee.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Employee.DataAccess
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeEntity>().HasQueryFilter(x => !x.Deleted);
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
