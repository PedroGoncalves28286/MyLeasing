using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public interface IRepository
    {
        void AddOwner(Owner owner);


        Owner GetOwner(int id);


        IEnumerable<Owner> GetOwners();


        bool OwnerExists(int id);


        void RemoveOwner(Owner owner);


        Task<bool> SaveAllAsync();


        void UpdateOwner(Owner owner);
    }
}