
using RestAPI_Maxxi.Helper;
using RestAPI_Maxxi.Models;

namespace RestAPI_Maxxi.Services
{
    public class EmpleadosService : IEmpleados
    {
        private readonly IEmpleadosRepositoryData _repositoryData;
        public EmpleadosService(IEmpleadosRepositoryData repositoryData)
        {
            _repositoryData = repositoryData;
        }

        public async Task<Empleados> CreateUser(Empleados empleado)
        {
            var result = new Empleados();
            if (!HelperGeneral.ValidaTelefono(empleado.Telefono))
                throw new Exception("El número telefónico es incorrecto"); 

            if (HelperGeneral.EsMayorDeEdad(HelperGeneral.ObtenerFechaNacimiento(empleado.FechaNacimiento)))
            {
                result = await _repositoryData.CreateUser(empleado);
            }
            else
            {
                throw new Exception("El empleado no es mayor de edad");
            }

            return result;
        }

        public async Task<int> DeleteUser(int idEmpleado)
        {
            return await _repositoryData.DeleteUser(idEmpleado);
        }

        public async Task<Empleados> GetUser(int idEmpleado)
        {
            return await _repositoryData.GetUser(idEmpleado);
        }

        public async Task<Empleados> UpdateUser(int idEmpleado, Empleados empleado)
        {
            return await _repositoryData.UpdateUser(idEmpleado, empleado);
        }
    }
}
