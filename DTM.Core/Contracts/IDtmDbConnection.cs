using MySql.Data.MySqlClient;

namespace DTM.Core.Contracts
{
    public interface IDtmDbConnection
    {
        MySqlConnection DbConnection { get; set; }
    }
}