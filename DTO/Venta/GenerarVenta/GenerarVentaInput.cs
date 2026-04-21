namespace TiendaRopa.DTO.Venta.GenerarVenta
{
    public class GenerarVentaInput
    {
        public int ClienteId { get; set; }
        public List<ProductoVentaInput> Productos { get; set; } = new();
    }

    public class ProductoVentaInput
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
