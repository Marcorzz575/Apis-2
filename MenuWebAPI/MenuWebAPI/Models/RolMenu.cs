namespace MenuWebAPI.Models
{
    public class RolMenu
{
    public int IdRolMenu { get; set; }
    public int? IdRol { get; set; }
    public int? IdMenu { get; set; }
    public int? IdStatusRegistro { get; set; }

    // Propiedades de navegación
    public virtual Rol? IdRolNavigation { get; set; }
    public virtual Menu? IdMenuNavigation { get; set; }
    public virtual CStatusRegistro? IdStatusRegistroNavigation { get; set; }
}
}