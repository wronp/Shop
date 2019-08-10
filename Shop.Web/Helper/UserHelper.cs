using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Shop.Web.Helper
{
    using Data.Entities;
    using Shop.Web.Models;

    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserHelper(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        #region Method to login and logout
        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await signInManager.PasswordSignInAsync(
                model.UserName, 
                model.Password, 
                model.RememberMe, 
                false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }
        #endregion
    }

}
