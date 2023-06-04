using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Owner ToOwner(OwnerViewModel model, string path, bool isNew)
        {
            return new Owner
            {
                Id=isNew ?0:model.Id,
                Document = model.Document,
                ImageUrl = path,
                Name = model.Name,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                Address = model.Address
            };
        }

        public OwnerViewModel ToOwnerViewModel(Owner owner)
        {
            return new OwnerViewModel
            {
                Id = owner.Id,
                Name = owner.Name,
                Document = owner.Document,
                CellPhone = owner.CellPhone,
                FixedPhone = owner.FixedPhone,
                Address = owner.Address,
                ImageUrl = owner.ImageUrl,
                
            };
        }
    }
}