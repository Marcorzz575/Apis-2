using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuWebAPI.Models;

namespace MenuWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosSatController : ControllerBase
    {
        private readonly DBVENTAMXAPIContext _context;

        public CatalogosSatController(DBVENTAMXAPIContext context)
        {
            _context = context;
        }

        [HttpGet("colonias/{cp}")]
        public async Task<IActionResult> GetColoniasPorCP(int cp)
        {
            var colonias = await _context.ColoniaSAT
                .Where(c => c.idCodigoPostal == cp)
                .ToListAsync();

            return Ok(colonias);
        }

        [HttpGet("localidades/{idEstado}")]
        public async Task<IActionResult> GetLocalidadesPorEstado(int idEstado)
        {
            var localidades = await _context.LocalidadesSAT
                .Where(l => l.idEstado == idEstado)
                .ToListAsync();

            return Ok(localidades);
        }
    }
}
