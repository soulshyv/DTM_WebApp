using System.Threading.Tasks;
using DTM.Encryption;
using UserManager.Contracts;

namespace UserManager.Services
{
    public class UserManager : IUserManager
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsConnected { get; private set; }

        public UserManager(IUserRepository userRepo, IMd5Encryption encryption)
        {
            UserRepo = userRepo;
            Encryption = encryption;
            IsConnected = false;
        }

        private IUserRepository UserRepo { get; set; }
        private IMd5Encryption Encryption { get; set; }

        public async Task<int> Connect(string username, string password)
        {
            var res = await UserRepo.GetUser(username);
            if (res == null) return -1;
            if (Encryption.Encrypt(password) != res) return 0;
            UserName = username;
            Password = password;
            IsConnected = true;
            return 1;
        }

        public bool Connected()
        {
            return IsConnected;
        }
    }
}
