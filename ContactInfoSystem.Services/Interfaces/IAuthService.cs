using ContactInfoSystem.Models;
using System.Threading.Tasks;

namespace ContactInfoSystem.Services.Interfaces
{
    public interface IAuthService
    {
        bool CreateUser(User user, string Password, string role);
        Task<bool> SignOut();
        User AuthenticateUser(string Username, string Password);
        User GetUser(string Username);
    }
}
