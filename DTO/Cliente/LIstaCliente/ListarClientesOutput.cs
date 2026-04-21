namespace TiendaRopa.DTO.Cliente
{
    public class ListarClientesOutput
    {
        public int ClienteID { get; set; }   // ID generado por la BD
        public int Ci { get; set; }
        public string? Extension { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
