using Microsoft.EntityFrameworkCore;
using Ejercicio.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EjercicioContext>(options =>
{
    options.UseSqlServer("server=LAPTOP-G7UV3UKS;database=Ejercicio;user=sa;password=123;TrustServerCertificate=true;");
});

var app = builder.Build();

app.UseCors(
     b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();