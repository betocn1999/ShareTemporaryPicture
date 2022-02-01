using Npgsql;
using System.Threading.Tasks;

namespace ShareTemporaryPicture.Repository
{
    public interface IPostgresConnection
    {
        NpgsqlConnection GetPostgresConnection();
    }
}