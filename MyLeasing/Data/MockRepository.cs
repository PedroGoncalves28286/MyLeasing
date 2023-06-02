using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class MockRepository : IRepository
    {
        public void AddOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public Owner GetOwner(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Owner> GetOwners()
        {
            var owners = new List<Owner>();
            owners.Add(new Owner { Document =1 , Name ="Um",FixedPhone ="10"});
            owners.Add(new Owner { Document = 2, Name = "dois", FixedPhone = "20" });
            owners.Add(new Owner { Document = 3, Name = "tres", FixedPhone = "30" });
            owners.Add(new Owner { Document = 4, Name = "quatro", FixedPhone = "40" });
            owners.Add(new Owner { Document = 5, Name = "cinco", FixedPhone = "50" });
            owners.Add(new Owner { Document = 6, Name = "seis", FixedPhone = "60" });
            owners.Add(new Owner { Document = 7, Name = "sete", FixedPhone = "70" });
            owners.Add(new Owner { Document = 8, Name = "oito", FixedPhone = "80" });
            owners.Add(new Owner { Document = 9, Name = "nove", FixedPhone = "90" });
            owners.Add(new Owner { Document = 10, Name = "dez", FixedPhone = "100" });

            return owners;
        }

        public bool OwnerExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }
    }
}
