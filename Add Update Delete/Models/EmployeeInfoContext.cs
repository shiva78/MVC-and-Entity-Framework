using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Add_Update_Delete.Models
{
    public class EmployeeInfoContext : DbContext
    {
        public EmployeeInfoContext() : base("MyDbConnection")
        {}
        public DbSet<EmployeeInfo> employeeInfo { get; set; }
    }
}