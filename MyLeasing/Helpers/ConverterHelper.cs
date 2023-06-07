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
        public Lessee ToLesse(LesseeViewModel model, string path, bool isNew)
        {
            return new Lessee
            {
                Id = isNew ? 0 : model.Id,
                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                ImageUrl = path,
                Address = model.Address,
                UserId = model.UserId,
                user = model.user


            };

        }
        public LesseeViewModel ToLesseeViewModel(Lessee lessee)
        {
            return new LesseeViewModel
            {
                Id = lessee.Id,
                Document = lessee.Document,
                FirstName = lessee.FirstName,
                LastName = lessee.LastName,
                FixedPhone = lessee.FixedPhone,
                CellPhone = lessee.CellPhone,
                ImageUrl = lessee.ImageUrl,
                Address = lessee.Address,
                UserId = lessee.UserId,
                user = lessee.user

            };

        }
    }
}