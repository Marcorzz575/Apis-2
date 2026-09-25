using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuWebAPI.Models;

namespace MenuWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly DBVENTAMXAPIContext _context;
        public MenusController(DBVENTAMXAPIContext context)
            {
                _context = context;
            }

            [HttpGet("PorRol/{idRol}")]
            public async Task<IActionResult> GetMenuPorRol(int idRol)
        {
            var menu = await _context.RolMenus
                .Where(rm => rm.IdRol == idRol && rm.IdStatusRegistro == 1)
                .Select(rm => new
                {
                    rm.IdMenu,
                    Descripcion = rm.IdMenuNavigation.Descripcion,
                    Icono = rm.IdMenuNavigation.Icono,
                    Controlador = rm.IdMenuNavigation.Controlador,
                    PaginaAccion = rm.IdMenuNavigation.PaginaAccion,
                    IdMenuPadre = rm.IdMenuNavigation.IdMenuPadre,
                })
                .ToListAsync();
            return Ok(menu);
        }
    }
}
