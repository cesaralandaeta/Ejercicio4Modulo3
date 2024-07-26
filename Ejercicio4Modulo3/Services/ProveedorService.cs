using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Repository;using Ejercicio4Modulo3.Services.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly Ejercicio4Modulo3Context _context;

        public ProveedorService(Ejercicio4Modulo3Context context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedor.ToListAsync();
        }

        public async Task<Proveedor> AddAsync(Proveedor proveedor)
        {
            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        
    }
}
