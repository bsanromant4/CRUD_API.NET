using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaMaxiTransfer.Models
{
    public class Beneficiarios
    {
        public int IdBeneficiario { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string FechaNacimiento { get; set; } = string.Empty;
        public string CURP { get; set; } = string.Empty;
        public string SSN { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;
        public int PorcentParticipacion { get; set; }
    }
}
