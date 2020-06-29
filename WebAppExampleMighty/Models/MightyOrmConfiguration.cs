using Microsoft.Extensions.Configuration;

namespace WebAppExampleMighty.Models
{
    public class MightyOrmConfiguration : IMightyOrmConfiguration
    {
        public string ConnectionString { get; }
        public MightyOrmConfiguration(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("MyDbConfiguration");
        }
    }
}
