using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class CopagoContext : DbContext
    {
        public CopagoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Paciente> Pacientes { get; set; }
	}
}
