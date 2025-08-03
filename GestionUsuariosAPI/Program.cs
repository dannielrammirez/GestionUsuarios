using GestionUsuariosAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS para permitir solicitudes desde el frontend Blazor
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: "AllowBlazorApp",
		builder =>
		{
			builder.WithOrigins("http://localhost:5017", "https://localhost:7001")
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorApp");

app.UseAuthorization();

app.MapControllers();

app.Run();