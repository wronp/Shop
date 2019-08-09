using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Shop.Web.Helper
{
    using Data.Entities;

    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password); // this send the result if the user has de user and password correct.
    }
}
