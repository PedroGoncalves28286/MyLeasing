using MyLeasing.Web.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                AddOwner("ZeManel");
                AddOwner("ZeAntonio");
                AddOwner("ZeZe");
                AddOwner("ZeJose");
                AddOwner("ZeZeca");
                AddOwner("ZeJoaquim");
                AddOwner("ZeJoca");
                AddOwner("ZeXula");
                AddOwner("ZeJusué");
                AddOwner("ZeZeCamarinha");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string name)
        {
            _context.Owners.Add(new Owner
            {
                Name = name,
                Document = GenerateRandomNumbers(6),
                FixedPhone = GenerateRandomNumbers(9),
                CellPhone = GenerateRandomNumbers(9),
                Address = GenerateRandomAddress(),
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
