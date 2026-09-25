using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuWebAPI.Models
{
    [Table("c_Usuario")]
    public class Usuario
    {
        [Key]
        [Column("idUsuario")]
        public int idUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nombre")]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("correo")]
        public string correo { get; set; } = string.Empty;

        [Required]
        [Column("telefono")]
        public string? telefono { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("clave")]
        public string clave { get; set; } = string.Empty;
        
        [Column("idRol")]
        public int idRol { get; set; }

        [Column("urlFoto")]
        public string? urlFoto { get; set; }

        [Column("nombreFoto")]
        public string? nombreFoto { get; set; }

        [Column("idStatusRegistro")]
        public int idStatusRegistro { get; set; }

        [Column("fechaRegistro")]
        public DateTime? fechaRegistro { get; set; }

        [ForeignKey("idRol")]
        public virtual Rol Rol { get; set; }

        [ForeignKey("idStatusRegistro")]
        public virtual CStatusRegistro? StatusRegistro { get; set; }
    }
}
