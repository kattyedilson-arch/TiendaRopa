using Microsoft.AspNetCore.Mvc;
using TiendaRopa.Entidades;

namespace TiendaRopa.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RopaController : ControllerBase
{
    private static readonly string[] Prendas = new[]
    {
        "Camisa", "Pantalón", "Vestido", "Chaqueta", "Zapatos", "Falda", "Sudadera", "Abrigo"
    };

    private readonly ILogger<RopaController> _logger;

    public RopaController(ILogger<RopaController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRopa")]
    public IEnumerable<ProductoRopa> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new ProductoRopa
        {
            Id = index, // ✅ tu entidad usa int
            Nombre = Prendas[Random.Shared.Next(Prendas.Length)],
            Talla = new[] { "S", "M", "L", "XL" }[Random.Shared.Next(4)],
            Precio = Random.Shared.Next(50, 500),
            Stock = Random.Shared.Next(0, 20),
            CategoriaId = 1 // valor ficticio para evitar null
        })
        .ToArray();
    }
}
