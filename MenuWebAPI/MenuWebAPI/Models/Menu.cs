using System.Collections.Generic;

namespace MenuWebAPI.Models
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public string? Descripcion { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
        public int? IdMenuPadre { get; set; }
        public int? IdStatusRegistro { get; set; }

        // Propiedades de navegación
        public virtual CStatusRegistro? IdStatusRegistroNavigation { get; set; }
        public virtual Menu? IdMenuPadreNavigation { get; set; }
        public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; set; } = new List<Menu>();
        public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();
    }
}