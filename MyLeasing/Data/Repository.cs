using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(p => p.OwnerName);
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Find(id);
        }

        public void AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
        }

        public void UpdateOwner(Owner owner)
        {
            _context.Owners.Update(owner);
        }

        public void RemoveOwner(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(p => p.Id == id);
        }
    }
}
