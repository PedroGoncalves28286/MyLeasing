using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            var user = await _userHelper.GetUserByIdAsync("pedromfonsecagoncalves@gmail.com");
            if (user == null)
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

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!_context.Owners.Any())
            {
                AddOwner("ZeManel", user);
                AddOwner("ZeAntonio", user);
                AddOwner("ZeZe", user);
                AddOwner("ZeJose", user);
                AddOwner("ZeZeca", user);
                AddOwner("ZeJoaquim", user);
                AddOwner("ZeJoca", user);
                AddOwner("ZeXula", user);
                AddOwner("ZeJusué", user);
                AddOwner("ZeZeCamarinha", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string name, User user)
        {
            _context.Owners.Add(new Owner
            {
                Name = name,
                Document = GenerateRandomNumbers(6),
                FixedPhone = GenerateRandomNumbers(9),
                CellPhone = GenerateRandomNumbers(9),
                Address = GenerateRandomAddress(),
                User = user
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
        private Random random = new Random();

        private async Task AddLessee(User user)
        {
            var lessee = new Lessee
            {
                Document = user.Document,
                FirstName = GenerateRandomFirstName(),
                LastName = GenerateRandomLastName(),
                FixedPhone = user.PhoneNumber,
                CellPhone = user.PhoneNumber,
                Address = GenerateRandomAddress()
            };

            await _lesseeRepository.CreateAsync(lessee);
        }

        private string GenerateRandomNumbers(int value)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < value; i++)
            {
                sb.Append(random.Next(0, 10));
            }

            return sb.ToString();
        }

        private string GenerateRandomFirstName()
        {
            string[] firstNames = { "John", "Jane", "Robert", "Emily", "Michael", "Olivia" };
            int index = random.Next(firstNames.Length);

            return firstNames[index];
        }

        private string GenerateRandomLastName()
        {
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia" };
            int index = random.Next(lastNames.Length);

            return lastNames[index];
        }

        private string GenerateRandomAddress()
        {
            string[] addresses = { "123 Main St", "456 Elm St", "789 Oak Ave", "321 Pine Rd", "987 Maple Ln" };
            int index = random.Next(addresses.Length);

            return addresses[index];
        }



    }


} 

