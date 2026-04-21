namespace TiendaRopa.DTO.Cliente.EliminarCliente
{
    public class EliminarClienteOutput
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Mensaje { get; set; } = "Cliente eliminado correctamente.";
    }
}
