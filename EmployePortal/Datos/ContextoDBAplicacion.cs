using EmployePortal.Modelos.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployePortal.Datos
{
    public class ContextoDBAplicacion : DbContext
    {
        public ContextoDBAplicacion(DbContextOptions<ContextoDBAplicacion> options) : base(options)
        {
            
        }

        public DbSet<employee> Employees{ get; set; }
    }
}
