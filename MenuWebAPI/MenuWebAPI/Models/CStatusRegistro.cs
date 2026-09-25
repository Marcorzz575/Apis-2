using System.Collections.Generic;

namespace MenuWebAPI.Models
{
    public class CStatusRegistro
    {
        public int IdStatusRegistro { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
        public virtual ICollection<RolMenu> RolMenu { get; set; } = new List<RolMenu>();
    }
}
