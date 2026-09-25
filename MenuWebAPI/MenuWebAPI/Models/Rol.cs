using System.Collections.Generic;

namespace MenuWebAPI.Models
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
        public int? IdStatusRegistro { get; set; }

        // Propiedades de navegación
        public virtual CStatusRegistro? IdStatusRegistroNavigation { get; set; }
        public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();
    }
}