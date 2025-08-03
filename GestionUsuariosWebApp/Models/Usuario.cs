using System.ComponentModel.DataAnnotations;

namespace GestionUsuariosWebApp.Models
{
	public class Usuario
	{
		public int? Id { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio")]
		[StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
		public string? Nombre { get; set; }

		[Required(ErrorMessage = "El email es obligatorio")]
		[StringLength(100, ErrorMessage = "El email no puede exceder los 100 caracteres")]
		[EmailAddress(ErrorMessage = "Introduce un email válido")]
		public string? Email { get; set; }
		public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
	}
}