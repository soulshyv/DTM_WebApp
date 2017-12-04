using DTM.Core.Contracts;
using MySql.Data.MySqlClient;

namespace DTM.Core.Services
{
    public class InClassName
    {
        public InClassName(string conn)
        {
            Conn = conn;
        }

        public string Conn { get; private set; }
    }

    public class DtmDbConnection : IDtmDbConnection
    {
        public DtmDbConnection(string conn)
        {
            DbConnection = new MySqlConnection(conn);
            DbConnection.Open();
        }

        public MySqlConnection DbConnection { get; set; }
    }
}
