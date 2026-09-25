using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuWebAPI.Models;

namespace MenuWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DBVENTAMXAPIContext _context;

        public AuthController(DBVENTAMXAPIContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.correo == login.Correo && u.clave == login.Clave && u.idStatusRegistro == 1);

            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas o usuario inactivo" });
            }

            var menus = await _context.RolMenus
                .Where(rm => rm.IdRol == usuario.idRol && rm.IdStatusRegistro == 1)
                .Include(rm => rm.IdMenuNavigation)
                .Select(rm => new
                {
                    rm.IdMenuNavigation.IdMenu,
                    rm.IdMenuNavigation.Descripcion,
                    rm.IdMenuNavigation.PaginaAccion,
                    rm.IdMenuNavigation.Icono
                })
                .ToListAsync();

            return Ok(new
            {
                usuario = new
                {
                    usuario.idUsuario,
                    usuario.nombre,
                    usuario.correo,
                    rol = usuario.Rol.Descripcion
                },
                menus = menus
            });
        }
    }

    public class LoginDTO
    {
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
    }
}
