using System;
using System.Threading.Tasks;
using DTM.Core.Contracts;
using MySql.Data.MySqlClient;
using UserManager.Contracts;

namespace DTM.UserManager.Services
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(IDtmDbConnection dbConnection)
        {
            Conn = dbConnection.DbConnection;
        }

        private MySqlConnection Conn { get; }

        public async Task<string> GetUser(string username)
        {
            const string sql = @"SELECT Pwd FROM Users WHERE UserName=@username";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@username", username);
            var reader = await cmd.ExecuteReaderAsync();

            if (reader == null)
                throw new Exception("Une erreur est survenue");

            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }

            reader.Read();
            var ret = reader["Pwd"].ToString();
            reader.Close();
            return ret;
        }

    }
}
