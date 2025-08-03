using GestionUsuariosWebApp.Models;
using System.Net.Http.Json;

namespace GestionUsuariosWebApp.Services
{
	public class UsuarioService
	{
		private readonly HttpClient _httpClient;

		public UsuarioService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Usuario>> GetUsuariosAsync()
		{
			var response = await _httpClient.GetAsync("api/Usuarios");
			response.EnsureSuccessStatusCode();

			return (await response.Content.ReadFromJsonAsync<List<Usuario>>())!;
		}

		public async Task<Usuario> GetUsuarioByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"api/Usuarios/{id}");
			response.EnsureSuccessStatusCode();

			return (await response.Content.ReadFromJsonAsync<Usuario>())!;
		}

		public async Task CreateUsuarioAsync(Usuario usuario)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Usuarios", usuario);

			response.EnsureSuccessStatusCode();
		}

		public async Task UpdateUsuarioAsync(Usuario usuario)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/Usuarios/{usuario.Id}", usuario);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteUsuarioAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"api/Usuarios/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}