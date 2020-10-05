using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC.Models
{
    public class EmployeeDbContext:DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
    }
}