using RestAPI_Maxxi.Models;
using RestAPI_Maxxi.Services;
using System.Data;
using System.Data.SqlClient;

namespace RestAPI_Maxxi.Data
{
    public class EmpleadosRepositoryData : IEmpleadosRepositoryData
    {
        private readonly DataDBContext _context;

        public EmpleadosRepositoryData(DataDBContext context) {
            _context = context;
        }

        public Task<Empleados> CreateUser(Empleados empleado)
        {
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertarEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                    command.Parameters.AddWithValue("@FechaNacimiento",  empleado.FechaNacimiento);
                    command.Parameters.AddWithValue("@NEmpleado", empleado.NEmpleado);
                    command.Parameters.AddWithValue("@CURP", empleado.CURP);
                    command.Parameters.AddWithValue("@SSN", empleado.SSN);
                    command.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                    command.Parameters.AddWithValue("@Nacionalidad", empleado.Nacionalidad);

                    int rowsAffected = command.ExecuteNonQuery();
                     using (SqlDataReader reader = command.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                            empleado.IdEmpleado = (int)reader.GetDecimal(reader.GetOrdinal("IdEmpleado"));
                        }
                     }
                }
            }

            return Task.FromResult(empleado);
        }

        public Task<int> DeleteUser(int idEmpleado)
        {
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("EliminarEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            return Task.FromResult(idEmpleado);
        }

        public Task<Empleados> GetUser(int idEmpleado)
        {
            var result = new Empleados();
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("SeleccionarEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    command.ExecuteNonQuery();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.IdEmpleado = reader.GetInt32(reader.GetOrdinal("IdEmpleado"));
                            result.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                            result.Apellidos = reader.GetString(reader.GetOrdinal("Apellidos"));
                            result.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")).ToString("dd/MM/yyyy");
                            result.NEmpleado = reader.GetInt32(reader.GetOrdinal("NEmpleado"));
                            result.CURP = reader.GetString(reader.GetOrdinal("CURP"));
                            result.SSN = reader.GetString(reader.GetOrdinal("SSN"));
                            result.Telefono = reader.GetString(reader.GetOrdinal("Telefono"));
                            result.Nacionalidad = reader.GetString(reader.GetOrdinal("Nacionalidad"));
                        }
                    }
                }
            }

            return Task.FromResult(result);
        }

        public Task<Empleados> UpdateUser(int idEmpleado, Empleados empleado)
        {
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("ActualizarEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                    command.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                    command.Parameters.AddWithValue("@NEmpleado", empleado.NEmpleado);
                    command.Parameters.AddWithValue("@CURP", empleado.CURP);
                    command.Parameters.AddWithValue("@SSN", empleado.SSN);
                    command.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                    command.Parameters.AddWithValue("@Nacionalidad", empleado.Nacionalidad);
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    command.ExecuteNonQuery();
                }
            }

            return Task.FromResult(empleado);
        }
    }
}
