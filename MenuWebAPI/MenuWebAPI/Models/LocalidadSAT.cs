using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuWebAPI.Models
{
    [Table("c_Localidad_SAT")]
    public class LocalidadSAT
    {
        [Key]
        [Column("idLocalidad")]
        public int idLocalidad { get; set; }

        [Column("c_Localidad")]
        public string c_Localidad { get; set; } = string.Empty;

        [Column("idEstado")]
        public int idEstado { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; } = string.Empty;

        [Column("fechaInicioVigencia")]
        public DateTime? fechaInicioVigencia { get; set; }

        [Column("fechaFinVigencia")]
        public DateTime? fechaFinVigencia { get; set; }

        [Column("idStatusRegistro")]
        public int? idStatusRegistro { get; set; }
    }
}
