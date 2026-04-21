using System;

namespace TiendaRopa.Entidades;

public class ProductoRopa
{
    public int Id { get; set; }  
    public string Nombre { get; set; } = string.Empty;
    public string Talla { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;       
    public ICollection<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();

}