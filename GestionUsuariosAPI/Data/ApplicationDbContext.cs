using GestionUsuariosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionUsuariosAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }
	}
}