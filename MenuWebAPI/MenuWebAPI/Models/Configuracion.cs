using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuWebAPI.Models
{
    [Table("c_Configuracion")]
    public class Configuracion
    {
        [Key]
        [Column("idConfiguracion")]
        public int IdConfiguracion {  get; set; }

        [Column("idNegocio")]
        public int? IdNegocio { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("recurso")]
        public string Recurso { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("propiedad")]
        public string Propiedad { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("valor")]
        public string Valor { get; set; } = string.Empty;

        [Column("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [Column("idStatusRegistro")]
        public int? IdStatusRegistro { get; set; }
    }
}
