namespace TiendaRopa.DTO.Cliente.ObtenerCliente
{
    public class ObtenerClienteOutput
    {
        public int Id { get; set; }
        public int Ci { get; set; }
        public string? Extension { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public bool? EsClientePorDefecto { get; set; }
    }
}

