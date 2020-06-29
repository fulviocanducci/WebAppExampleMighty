using Mighty;

namespace WebAppExampleMighty.Models
{
    public class DaoPerson : MightyOrm<Person>
    {
        public DaoPerson(IMightyOrmConfiguration configuration)
            : base(connectionString: configuration.ConnectionString)
        {
        }
    }
}
