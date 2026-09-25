using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuWebAPI.Models;

namespace MenuWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DBVENTAMXAPIContext _context;
        public UsuariosController(DBVENTAMXAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.StatusRegistro)
                .Select(u => new
                {
                    u.idUsuario,
                    u.nombre,
                    u.correo,
                    u.idRol,
                    rol = u.Rol != null ? u.Rol.Descripcion : string.Empty,
                    u.idStatusRegistro,
                    status = u.StatusRegistro != null ? u.StatusRegistro.Descripcion : string.Empty,
                    u.fechaRegistro
                })
                .ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.idUsuario == id);

            if (usuario == null)
                return NotFound(new { mensaje = "Usuario no encontrado" });

            return Ok(new
            {
                usuario.idUsuario,
                usuario.nombre,
                usuario.correo,
                usuario.idRol,
                usuario.idStatusRegistro
            });
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            usuario.fechaRegistro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario creado exitosamente", id = usuario.idUsuario});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.idUsuario)
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con el registro" });

            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                return NotFound(new { mensaje = "El usuario no existe" });

            usuarioExistente.nombre = usuario.nombre;
            usuarioExistente.correo = usuario.correo;
            usuarioExistente.idRol = usuario.idRol;
            usuarioExistente.idStatusRegistro = usuario.idStatusRegistro;

            if (!string.IsNullOrEmpty(usuario.clave))
            {
                usuarioExistente.clave = usuario.clave;
            }

            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Usuario actualizado correctamente" });
        }
    }
}
