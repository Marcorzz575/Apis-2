using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuWebAPI.Models
{
    [Table("c_Colonia_SAT")]
    public class ColoniaSAT
    {
        [Key]
        [Column("idColonia")]
        public int idColonia { get; set; }

        [Column("c_Colonia")]
        public string c_Colonia { get; set; } = string.Empty;

        [Column("idCodigoPostal")]
        public int idCodigoPostal { get; set; }

        [Column("nombreDelAsentamiento")]
        public string nombre { get; set; } = string.Empty;

        [Column("idStatusRegistro")]
        public int? idStatusRegistro { get; set; }
    }
}
