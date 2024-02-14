using Microsoft.AspNetCore.Components.Web;
using System.Text.RegularExpressions;

namespace RestAPI_Maxxi.Helper
{
    public static class HelperGeneral
    {
        public static bool EsMayorDeEdad(DateOnly fechaNacimiento)
        {
            // Obtener la fecha actual
            var timeNow = DateTime.Now.ToString("dd/MM/yyyy").Split("/");
            var fechaActual = new DateOnly(int.Parse(timeNow[2]), int.Parse(timeNow[1]), int.Parse(timeNow[0]));

            // Calcular la edad de la persona
            var edad = fechaActual.Year - fechaNacimiento.Year;

            // Verificar si la fecha de nacimiento ya ocurrió este año
            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            // Verificar si la persona es mayor de edad (mayor o igual a 18 años)
            return edad >= 18;
        }

        public static DateOnly ObtenerFechaNacimiento(string fchaNacimiento)
        {
            var _fchaNac = fchaNacimiento.Split('/');
            return new DateOnly(int.Parse(_fchaNac[0]), int.Parse(_fchaNac[1]), int.Parse(_fchaNac[2]) );
        }

        public static bool ValidaTelefono(string numeroTelefono)
        {
            Regex regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(numeroTelefono);
        }
    }
}
