using RestAPI_Maxxi.Models;
using RestAPI_Maxxi.Services;
using System.Data;
using System.Data.SqlClient;

namespace RestAPI_Maxxi.Data
{
    public class BeneficiarioRepositoryData : IBeneficiarioRepositoryData
    {
        private readonly DataDBContext _context;

        public BeneficiarioRepositoryData(DataDBContext context)
        {
            _context = context;
        }

        public Task<Beneficiarios> CreateUser(Beneficiarios beneficiario)
        {
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertarBeneficiario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEmpleado", beneficiario.IdEmpleado);
                    command.Parameters.AddWithValue("@Nombre", beneficiario.Nombre);
                    command.Parameters.AddWithValue("@Apellidos", beneficiario.Apellidos);
                    command.Parameters.AddWithValue("@FechaNacimiento", beneficiario.FechaNacimiento);
                    command.Parameters.AddWithValue("@CURP", beneficiario.CURP);
                    command.Parameters.AddWithValue("@SSN", beneficiario.SSN);
                    command.Parameters.AddWithValue("@Telefono", beneficiario.Telefono);
                    command.Parameters.AddWithValue("@Nacionalidad", beneficiario.Nacionalidad);
                    command.Parameters.AddWithValue("@PorcentParticipacion", beneficiario.PorcentParticipacion);

                    int rowsAffected = command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beneficiario.IdBeneficiario = (int)reader.GetDecimal(reader.GetOrdinal("IdBeneficiario"));
                        }
                    }
                }
            }

            return Task.FromResult(beneficiario);
        }

        public Task<int> DeleteUser(int idBeneficiario)
        {
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("EliminarBeneficiario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBeneficiario", idBeneficiario);

                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            return Task.FromResult(idBeneficiario);
        }

        public Task<List<Beneficiarios>> GetByEmployee(int idEmpleado)
        {
            var result = new List<Beneficiarios>();
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("SeleccionarBeneficiarioxEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    command.ExecuteNonQuery();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Beneficiarios();
                            item.IdBeneficiario = reader.GetInt32(reader.GetOrdinal("IdBeneficiario"));
                            item.IdEmpleado = reader.GetInt32(reader.GetOrdinal("IdEmpleado"));
                            item.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                            item.Apellidos = reader.GetString(reader.GetOrdinal("Apellidos"));
                            item.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")).ToString("dd/MM/yyyy");
                            item.CURP = reader.GetString(reader.GetOrdinal("CURP"));
                            item.SSN = reader.GetString(reader.GetOrdinal("SSN"));
                            item.Telefono = reader.GetString(reader.GetOrdinal("Telefono"));
                            item.Nacionalidad = reader.GetString(reader.GetOrdinal("Nacionalidad"));
                            item.PorcentParticipacion = reader.GetInt32(reader.GetOrdinal("PorcentParticipacion"));
                            result.Add(item);
                        }
                    }
                }
            }

            return Task.FromResult(result);
        }

        public Task<Beneficiarios> GetUser(int idBeneficiario)
        {
            var result = new Beneficiarios();
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("SeleccionarBeneficiario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBeneficiario", idBeneficiario);
                    command.ExecuteNonQuery();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.IdBeneficiario = reader.GetInt32(reader.GetOrdinal("IdBeneficiario"));
                            result.IdEmpleado = reader.GetInt32(reader.GetOrdinal("IdEmpleado"));
                            result.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                            result.Apellidos = reader.GetString(reader.GetOrdinal("Apellidos"));
                            result.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")).ToString("dd/MM/yyyy");
                            result.CURP = reader.GetString(reader.GetOrdinal("CURP"));
                            result.SSN = reader.GetString(reader.GetOrdinal("SSN"));
                            result.Telefono = reader.GetString(reader.GetOrdinal("Telefono"));
                            result.Nacionalidad = reader.GetString(reader.GetOrdinal("Nacionalidad"));
                            result.PorcentParticipacion = reader.GetInt32(reader.GetOrdinal("PorcentParticipacion"));
                        }
                    }
                }
            }

            return Task.FromResult(result);
        }

        public Task<Beneficiarios> UpdateUser(int idBeneficiario, Beneficiarios beneficiario)
        {
            using (SqlConnection connection = new SqlConnection(_context.GetConnectionString()))
            {
                // Abrir la conexión
                connection.Open();

                using (SqlCommand command = new SqlCommand("ActualizarBeneficiario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBeneficiario", idBeneficiario);
                    command.Parameters.AddWithValue("@IdEmpleado", beneficiario.IdEmpleado);
                    command.Parameters.AddWithValue("@Nombre", beneficiario.Nombre);
                    command.Parameters.AddWithValue("@Apellidos", beneficiario.Apellidos);
                    command.Parameters.AddWithValue("@FechaNacimiento", beneficiario.FechaNacimiento);
                    command.Parameters.AddWithValue("@CURP", beneficiario.CURP);
                    command.Parameters.AddWithValue("@SSN", beneficiario.SSN);
                    command.Parameters.AddWithValue("@Telefono", beneficiario.Telefono);
                    command.Parameters.AddWithValue("@Nacionalidad", beneficiario.Nacionalidad);
                    command.Parameters.AddWithValue("@PorcentParticipacion", beneficiario.PorcentParticipacion);

                    command.ExecuteNonQuery();
                }
            }

            return Task.FromResult(beneficiario);
        }
    }
}
