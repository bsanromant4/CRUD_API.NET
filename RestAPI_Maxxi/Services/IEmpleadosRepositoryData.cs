using RestAPI_Maxxi.Models;

namespace RestAPI_Maxxi.Services
{
    public interface IEmpleadosRepositoryData
    {
        Task<Empleados> CreateUser(Empleados empleado);
        Task<Empleados> UpdateUser(int idEmpleado, Empleados empleado);
        Task<int> DeleteUser(int idEmpleado);
        Task<Empleados> GetUser(int idEmpleado);
    }
}
