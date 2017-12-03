using MySql.Data.MySqlClient;

namespace DTM.Core.Services
{
    public class DtmDbConnection : IDtmDbConnection
    {
        public DtmDbConnection(string conn)
        {
            DbConnection = new MySqlConnection(conn);
        }

        public MySqlConnection DbConnection { get; set; }
    }
}
