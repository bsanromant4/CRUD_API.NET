using System.ComponentModel.DataAnnotations;

namespace RestAPI_Maxxi.Models
{
    public class Beneficiarios
    {
        public int IdBeneficiario { get; set; }
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Apellidos { get; set; } = string.Empty;
        [Required]
        public string FechaNacimiento { get; set; } = string.Empty;
        [Required]
        public string CURP { get; set; } = string.Empty;
        [Required]
        public string SSN { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener exactamente 10 dígitos.")]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        public string Nacionalidad { get; set; } = string.Empty;
        [Required]
        public int PorcentParticipacion { get; set; }

    }
}
