using MealServices.DataLayer.Entities;
using MealServices.Shared.TransfertObjects;
using MealServices.Shared.Extensions;
using System;

namespace MealServices.DataLayer.Extensions
{
    public static class SupplierExtensions
    {
        public static SupplierTO ToTranfertObject(this SupplierEF Supplier)
            => new SupplierTO
            {
                Id = Supplier.Id,
                Name = Supplier.Name,
                IsDefault = Supplier.IsDefault
            };

        public static SupplierEF ToEF(this SupplierTO Supplier)
            => new SupplierEF
            {
                Id = Supplier.Id,
                Name = Supplier.Name,
                IsDefault = Supplier.IsDefault
            };

        public static SupplierEF UpdateFromDetached(this SupplierEF AttachedEF, SupplierEF DetachedEF)
        {
            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update SupplierEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Id = AttachedEF.Id;
                AttachedEF.Name = DetachedEF.Name;
                AttachedEF.IsDefault = DetachedEF.IsDefault;
            }

            return AttachedEF;
        }
    }
}
