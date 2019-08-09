using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{

    using Entities;
    using Helper;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            random = new Random();
        }

        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();

            var user = await userHelper.GetUserByEmailAsync("carlosm@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Carlos",
                    LastName = "Montoya",
                    Email = "carlosm@gmail.com",
                    UserName = "carlosm@gmail.com",
                    PhoneNumber = "1234567"
                };

                var result = await userHelper.AddUserAsync(user, "123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!context.Products.Any())
            {
                AddProduct("iPhone X", user);
                AddProduct("Magic Mouse", user);
                AddProduct("iWatch Series 4", user);
                await context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            context.Products.Add(new Product
            {
                Name = name,
                Price = random.Next(100),
                IsAvailabe = true,
                Stock = random.Next(100),
                User = user

            });
        }
    }

}