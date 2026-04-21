using System;
namespace TiendaRopa.Entidades
{
    public class VentaDetalle
    {
        public int Id { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; } = null!;

        public int ProductoId { get; set; }
        public ProductoRopa Producto { get; set; } = null!;

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
