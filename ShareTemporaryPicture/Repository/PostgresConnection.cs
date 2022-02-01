using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Threading.Tasks;

namespace ShareTemporaryPicture.Repository
{
    public class PostgresConnection : IPostgresConnection
    {
        private readonly NpgsqlConnection sqlConnection;

        public PostgresConnection(IConfiguration _configuration) => sqlConnection = new NpgsqlConnection(_configuration.GetValue<string>("DataBaseConnection"));

        public NpgsqlConnection GetPostgresConnection() => sqlConnection;
    }
}