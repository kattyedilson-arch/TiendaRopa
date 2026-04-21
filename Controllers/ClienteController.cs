using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaRopa.Data;
using TiendaRopa.Entidades;
using TiendaRopa.DTO.Cliente.ObtenerCliente;
using TiendaRopa.DTO.Cliente.EliminarCliente;

namespace TiendaRopa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _contexto;

        public ClientesController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Cliente>>> GetClientes()
        {
            var clientes = await _contexto.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObtenerClienteOutput>> ObtenerCliente(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound($"Cliente con Id {id} no existe");

            return new ObtenerClienteOutput
            {
                Id = cliente.Id,
                Ci = cliente.Ci,
                Extension = cliente.Extension,
                Nombre = cliente.Nombre,
                FechaNacimiento = cliente.FechaNacimiento,
                EsClientePorDefecto = cliente.EsClientePorDefecto
            };
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente([FromBody] Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerCliente), new { id = cliente.Id }, cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EliminarClienteOutput>> DeleteCliente(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound($"Cliente con Id {id} no existe");

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();

            return new EliminarClienteOutput
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Mensaje = "Cliente eliminado correctamente."
            };
        }
    }
}
