using System;

namespace TiendaRopa.DTO.Cliente
{
    public class AgregarClienteOutput
    {
        public int ClienteID { get; set; }   
        public int Ci { get; set; }
        public string? Extension { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
