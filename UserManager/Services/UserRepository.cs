using System;
using System.Threading.Tasks;
using DTM.Core.Services;
using MySql.Data.MySqlClient;
using UserManager.Contracts;

namespace UserManager.Services
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(IDtmDbConnection dbConnection)
        {
            try
            {
                Conn = dbConnection.DbConnection;
                Conn.Open();
            }
            catch (Exception)
            {
                Conn.Close();
                throw new Exception("Une erreur est survenue pendant la connexion à la base de données");
            }
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

            if (!reader.HasRows || reader.FieldCount != 1)
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
