using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuWebAPI.Models;

namespace MenuWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly DBVENTAMXAPIContext _context;

        public ConfiguracionController(DBVENTAMXAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetConfiguraciones()
        {
            var configs = await _context.Configuraciones
                .Where(c => c.IdStatusRegistro == 1)
                .ToListAsync();

            return Ok(configs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarConfiguracion(int id, [FromBody] Configuracion config)
        {
            if (id != config.IdConfiguracion)
                return BadRequest(new { mensaje = "El ID no coincide" });

            var configExistente = await _context.Configuraciones.FindAsync(id);
            if (configExistente == null)
                return NotFound(new { mensaje = "La configuración no existe" });

            configExistente.Valor = config.Valor;
            configExistente.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Configuración actualizada correctamente" });
        }
    }
}
