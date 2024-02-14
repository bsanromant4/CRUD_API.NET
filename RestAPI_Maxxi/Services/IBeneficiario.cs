using RestAPI_Maxxi.Models;

namespace RestAPI_Maxxi.Services
{
    public interface IBeneficiario
    {
        Task<List<Beneficiarios>> CreateUser(int idBeneficiario, List<Beneficiarios> beneficiario);
        Task<Beneficiarios> UpdateUser(int idBeneficiario, Beneficiarios beneficiario);
        Task<int> DeleteUser(int idBeneficiario);
        Task<Beneficiarios> GetUser(int idBeneficiario);
        Task<List<Beneficiarios>> GetByEmployee(int idEmpleado);
    }
}
