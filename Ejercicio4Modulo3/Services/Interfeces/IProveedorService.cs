using Ejercicio4Modulo3.Domain.Entities;

namespace Ejercicio4Modulo3.Services.Interfeces
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> GetAllAsync();
        Task<Proveedor> AddAsync(Proveedor proveedor);
    }
}
