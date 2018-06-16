using System.Threading.Tasks;

namespace DTM.UserManager.Contracts
{
    public interface IUserRepository
    {
        Task<string> GetUser(string username);
    }
}