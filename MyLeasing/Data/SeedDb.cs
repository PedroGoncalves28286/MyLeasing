using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            var user = await _userHelper.GetUserByIdAsync("pedromfonsecagoncalves@gmail.com");
            if(user == null)
            {
                user = new User
                {
                    FirstName = "Pedro",
                    LastName = "Goncalves",
                    Document = GenerateRandomNumbers(6),
                    Address = GenerateRandomAddress(),
                    Email = "pedromfonsecagoncalves@gmail.com",
                    PhoneNumber = GenerateRandomNumbers(6),

                };

                var result = await _userHelper.AddUserAsync(user,"123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!_context.Owners.Any())
            {
                AddOwner("ZeManel",user);
                AddOwner("ZeAntonio",user);
                AddOwner("ZeZe",user);
                AddOwner("ZeJose",user);
                AddOwner("ZeZeca",user);
                AddOwner("ZeJoaquim",user);
                AddOwner("ZeJoca",user);
                AddOwner("ZeXula",user);
                AddOwner("ZeJusué",user);
                AddOwner("ZeZeCamarinha",user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string name,User user)
        {
            _context.Owners.Add(new Owner
            {
                Name = name,
                Document = GenerateRandomNumbers(6),
                FixedPhone = GenerateRandomNumbers(9),
                CellPhone = GenerateRandomNumbers(9),
                Address = GenerateRandomAddress(),
                User =user
            });
        }

        private string GenerateRandomNumbers(int length)
        {
            const string numbers = "0123456789";
            return new string(Enumerable.Repeat(numbers, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomAddress()
        {
            return "Random Address";
        }
    }
}
