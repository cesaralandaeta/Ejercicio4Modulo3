using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Repository;
using System.Diagnostics;

namespace Ejercicio4Modulo3.Middleware
{
    public class LoggingMiddleware:IMiddleware
    {
        private readonly Ejercicio4Modulo3Context _context;

        public LoggingMiddleware(Ejercicio4Modulo3Context context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           

            var log = new Logs
            {
             Path = context.Request.Path,
             Method = context.Request.Method,
             Fecha = DateTime.UtcNow
            };

            try
            {
                await next(context);
                log.Success = true;
            }
            catch (Exception)
            {
                log.Success = false;
                throw;
            }
            finally
            {
                _context.Logs.Add(log);
                await _context.SaveChangesAsync();
            }
        }
    }
}
