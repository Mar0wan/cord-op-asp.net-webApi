using dm.api.E_Models;
using Microsoft.EntityFrameworkCore;

namespace dm.Api.DbContexts
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options)
           : base(options) { }


        public DbSet<Employee> Employees { get; set; }

    }
}

