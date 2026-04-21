using Microsoft.AspNetCore.Mvc;
using TiendaRopa.Data;
using TiendaRopa.Entidades;
using TiendaRopa.DTO.Venta.GenerarVenta;

namespace TiendaRopa.Controllers;

public class VentasController : BaseApiController
{
    private readonly AppDbContext _context;

    public VentasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("GenerarVenta")]
public async Task<ActionResult<Venta>> GenerarVenta([FromBody] GenerarVentaInput entrada)
{
    // Crear la venta principal
    var venta = new Venta
    {
        Fecha = DateTime.Now,
        ClienteId = entrada.ClienteId,
        Total = 0m,
        Detalles = new List<VentaDetalle>()
    };

    // Recorrer los productos enviados en el DTO
    foreach (var item in entrada.Productos)
    {
        var producto = await _context.ProductoRopa.FindAsync(item.ProductoId);
        if (producto == null)
            return NotFound($"Producto con Id {item.ProductoId} no existe");

        var detalle = new VentaDetalle
        {
            ProductoId = producto.Id,
            Cantidad = item.Cantidad,
            PrecioUnitario = producto.Precio,
            Venta = venta
        };

        venta.Detalles.Add(detalle);
        venta.Total += detalle.Cantidad * detalle.PrecioUnitario;

        // Actualizar stock
        producto.Stock -= item.Cantidad;
    }

    _context.Ventas.Add(venta);
    await _context.SaveChangesAsync();

    return Ok(venta);
}

}
