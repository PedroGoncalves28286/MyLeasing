using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Commom.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ILesseeRepository _lesseeRepository;
        private Random _random;
        public SeedDb(DataContext context, IUserHelper userHelper, IOwnerRepository ownerRepository, ILesseeRepository lesseeRepository)
        {
            _context = context;
            _userHelper = userHelper;
            _ownerRepository = ownerRepository;
            _lesseeRepository = lesseeRepository;
            _random = new Random();
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            for (int i = 0; i < 5; i++)
            {

                User user = await GenerateUserAsync();
                await AddOwner(user);
            }

            for (int i = 0; i < 5; i++)
            {

                User user = await GenerateUserAsync();
                await AddLessee(user);
            }
            await _context.SaveChangesAsync();

            var getUser = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");
        }
        private async Task<User> GenerateUserAsync()
        {
            var name = GenerateRandomFirstName();
            var email = GenerateRandomEmail(name);
            var user = new User
            {
                FirstName = GenerateRandomFirstName(),
                LastName = GenerateRandomLastName(),
                UserName = email,
                Document = GenerateRandomNumbers(6),
                Address = GenerateRandomAddress(),
                Email = email,
                PhoneNumber = GenerateRandomNumbers(6),

            };

            var result = await _userHelper.AddUserAsync(user, "123456");
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create the user");
            }
            return user;
        }
        private async Task AddOwner(User user)
        {
            var owner = new Owner
            {
                Document = user.Document,
                OwnerName = user.Name,
                FixedPhone = user.PhoneNumber,
                CellPhone = user.PhoneNumber,
                Address = user.Address,
                UserId = user.Id,
                User = user
            };
            await _ownerRepository.CreateAsync(owner);
        }

        private async Task AddLessee(User user)
        {
            var lesse = new Lessee
            {
                Document = user.Document,
                FirstName = GenerateRandomFirstName(),
                LastName = GenerateRandomLastName(),
                FixedPhone = user.PhoneNumber,
                CellPhone = user.PhoneNumber,
                Address = GenerateRandomAddress(),

            };

            await _lesseeRepository.CreateAsync(lesse);

        }

        private string GenerateRandomNumbers(int value)
        {
            string phoneNumber = "";
            for (int i = 0; i < value; i++)
            {
                phoneNumber += _random.Next(10).ToString();
            }
            return phoneNumber;
        }

        private string GenerateRandomName()
        {
            string[] Names = { "John Smith", "Jane Johnson", "Robert Williams", "Emily Brown", "Michael Jones", "Olivia " };
            int index = random.Next(Names.Length);

            return Names[index];
        }

        private string GenerateRandomAddress()
        {
            string[] addresses = { "123 Main St", "456 Elm St", "789 Oak Ave", "321 Pine Rd", "987 Maple Ln" };
            int index = random.Next(addresses.Length);

            return addresses[index];
        }
        private string GenerateRandomEmail(string email)
        {
            string[] domains = { "gmail.com", "hotmail.com", "Yahoo.com" };
            string randomString = Guid.NewGuid().ToString().Substring(0, 8);

            // Concatenando com o domínio
            email = randomString + "@" + _random.Next(domains.Length);

            return email;
        }



    }


}

