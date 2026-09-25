using System.ComponentModel.DataAnnotations;

namespace APIClaveProdServ_SAT.Dto
{
    public class ClaveProdServDto
    {
        public int idClaveProdServ { get; set; }
        public string? c_ClaveProdServ { get; set; }
        public string? descripcion { get; set; }
        public string? incluirIvaTraslado { get; set; }
        public string? incluirIepsTraslado { get; set; }
        public DateOnly? fechaInicioVigencia { get; set; }
        public DateOnly? fechaFinVigencia { get; set; }
        public string? estimuloFranjaFronteriza { get; set; }
        public string? palabrasSimilares { get; set; }
        public int? idStatusRegistro { get; set; }
    }

    public class CreaClaveProdServDto
    {
        [StringLength(8, MinimumLength = 8, ErrorMessage = "La clave del SAT debe tener exactamente 8 caracteres.")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "La clave debe componerse únicamente de 8 dígitos numéricos.")]
        public string? c_ClaveProdServ { get; set; }
        [StringLength(160, ErrorMessage = "La descripción no puede exceder los 160 caracteres.")]
        public string? descripcion { get; set; }
        [StringLength(8, ErrorMessage = "El campo 'incluirIvaTraslado' no debe superar los 8 caracteres.")]
        public string? incluirIvaTraslado { get; set; }
        [StringLength(8, ErrorMessage = "El campo 'incluirIepsTraslado' no debe superar los 8 caracteres.")]
        public string? incluirIepsTraslado { get; set; }
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de inicio de vigencia no es válido (use AAAA-MM-DD).")]
        public DateOnly fechaInicioVigencia { get; set; }
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de fin de vigencia no es válido (use AAAA-MM-DD).")]
        public DateOnly fechaFinVigencia { get; set; }
        [StringLength(1, ErrorMessage = "El estímulo de franja fronteriza debe ser de solo 1 carácter (p. ej., '0' o '1').")]
        public string? estimuloFranjaFronteriza { get; set; }
        [StringLength(540, ErrorMessage = "Las palabras similares no deben exceder los 540 caracteres.")]
        public string? palabrasSimilares { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El estatus de registro debe ser un número entero válido.")]
        public int? idStatusRegistro { get; set; }
    }
}
