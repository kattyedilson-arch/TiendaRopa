using System;
using System.Security.Authentication;

namespace TiendaRopa.DTO.Cliente
{
    public class AgregarClienteInput
    {
        public int Ci { get; set; }
        public string? Extension { get; set; }
        public string Nombre { get; set; } = string.Empty; // más compatible que "required"
        public DateTime FechaNacimiento { get; set; }
    }
}
