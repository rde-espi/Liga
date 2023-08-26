using Liga.web.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Liga.web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult>AddUserAsync(User user, string password);
    }
}
