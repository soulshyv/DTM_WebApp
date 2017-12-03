using MySql.Data.MySqlClient;

namespace DTM.Core.Services
{
    public interface IDtmDbConnection
    {
        MySqlConnection DbConnection { get; set; }
    }
}