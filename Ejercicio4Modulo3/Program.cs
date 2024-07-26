using Ejercicio4Modulo3.Middleware;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Services.Interfeces;
using Ejercicio4Modulo3.Services;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IProveedorService, ProveedorService>();
            builder.Services.AddScoped<LoggingMiddleware>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Ejercicio4Modulo3Context>(opt =>
            {
                opt.UseSqlServer(connection);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseMiddleware<LoggingMiddleware>();

            app.Run();
        }
    }
}