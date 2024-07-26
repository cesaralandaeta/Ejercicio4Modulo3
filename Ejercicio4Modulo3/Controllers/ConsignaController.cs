using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Services.Interfeces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4Modulo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignaController : ControllerBase
    {

        // Correr el script para tener los datos de la BD
        // Se debe crear con la arquitectura en capas( el controller y services) para poder unicamente dar de alta un proveedor y recuperar todos los proveedores
        // Todas las peticiones tienen que ser async
        // Crear un middleware personalizado, que grabe en base de datos en la tabla logs cada interaccion que exista con los endpoints expuestos:
        // Si hay un error en la peticion se debe grabar success = false  sino success = true
        // para completar los datos de path y verbo http deben usar los metodos/propiedades
        // de la variable "context" que se disponibiliza al implementar IMiddleware
        private readonly IProveedorService _proveedorService;

        public ConsignaController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _proveedorService.GetAllAsync();
            return Ok(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest();
            }

            var createdProveedor = await _proveedorService.AddAsync(proveedor);
            return CreatedAtAction(nameof(GetAll), new { id = createdProveedor.Id }, createdProveedor);
        }
    }
}
