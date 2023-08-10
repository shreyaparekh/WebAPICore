using Microsoft.EntityFrameworkCore;

namespace WebAPiCore.Model
{
    public class EmployeeContext :  DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public  DbSet<TblEmployee> TblEmployees { get; set; }
        public DbSet<TblDesignation> TblDesignations { get; set;}
    }
}
