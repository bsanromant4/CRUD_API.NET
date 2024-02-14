
using RestAPI_Maxxi.Helper;
using RestAPI_Maxxi.Models;

namespace RestAPI_Maxxi.Services
{
    public class BeneficiariosService : IBeneficiario
    {
        private readonly IBeneficiarioRepositoryData _repositoryData;
        private readonly IEmpleadosRepositoryData _repositoryEmpleadosData;
        public BeneficiariosService(IBeneficiarioRepositoryData repositoryData, IEmpleadosRepositoryData empleadosRepositoryData )
        {
            _repositoryData = repositoryData;
            _repositoryEmpleadosData = empleadosRepositoryData;
        }

        public async Task<List<Beneficiarios>> CreateUser(int idEmpleado, List<Beneficiarios> beneficiario)
        {
            foreach (var item in beneficiario)
            {
                if (!HelperGeneral.EsMayorDeEdad(HelperGeneral.ObtenerFechaNacimiento(item.FechaNacimiento)))
                {
                    throw new Exception("El empleado no es mayor de edad");
                }
            }

            // Verificamos si el empleado existe
            var empleado = _repositoryEmpleadosData.GetUser(idEmpleado);
            if (empleado != null) {
                var sumaPorcentaje = beneficiario.Sum(x => x.PorcentParticipacion);

                // Verificamos que el % sea el 100%
                if (sumaPorcentaje == 100)
                {
                    foreach (var item in beneficiario)
                    {
                        item.IdEmpleado = idEmpleado;
                        var result = await _repositoryData.CreateUser(item);
                        item.IdBeneficiario = result.IdBeneficiario;
                    }
                }
            }
            else
            {
                throw new Exception("El empleado indicado no existe");
            }
            
            return beneficiario;
        }

        public async Task<int> DeleteUser(int IdBeneficiario)
        {
            return await _repositoryData.DeleteUser(IdBeneficiario);
        }

        public async Task<List<Beneficiarios>> GetByEmployee(int idEmpleado)
        {
            return await _repositoryData.GetByEmployee(idEmpleado);
        }

        public async Task<Beneficiarios> GetUser(int IdBeneficiario)
        {
            return await _repositoryData.GetUser(IdBeneficiario);
        }

        public async Task<Beneficiarios> UpdateUser(int IdBeneficiario, Beneficiarios beneficiario)
        {
            return await _repositoryData.UpdateUser(IdBeneficiario, beneficiario);
        }
    }
}
