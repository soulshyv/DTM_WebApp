using System.Threading.Tasks;

namespace UserManager.Contracts
{
    public interface IUserRepository
    {
        Task<string> GetUser(string username);
    }
}