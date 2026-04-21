using System;

namespace TiendaRopa.Entidades;

public class Venta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

    // Relación con Cliente
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    // Relación con Productos vendidos
    public ICollection<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();
}