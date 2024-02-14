using Microsoft.EntityFrameworkCore;

namespace RestAPI_Maxxi.Data
{
    public class DataDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private string _connectionString = string.Empty;

        public DataDBContext(DbContextOptions<DataDBContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        public DataDBContext(IConfiguration configuration): base()
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_configuration.GetConnectionString("SQLServerConnection")))
            {
                _connectionString = _configuration.GetConnectionString("SQLServerConnection");
            }
            return _connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("SQLServerConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
