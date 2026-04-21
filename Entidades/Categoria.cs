using System;

namespace TiendaRopa.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public ICollection<ProductoRopa> Productos { get; set; } = new List<ProductoRopa>();
    }
}



