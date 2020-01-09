﻿using MealServices.DataLayer.Entities;
using MealServices.DataLayer.Extensions;

using Microsoft.EntityFrameworkCore;
using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.MealServices.Interfaces;
using OnlineServices.Shared.MealServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Repositories
{
    public class SupplierRepository2 : GenericRepositoryTO<SupplierEF, SupplierTO, int>, ISupplierRepository2
    {
        private readonly MealContext mealContext;
        private IRepository<SupplierTO, int> localRepo;

        public SupplierRepository2(MealContext ContextIoC): base(ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in SupplierRepository");
            localRepo = this;
        }

        private bool isDefaultSupplierUniquenessWithThrow(string MethodName)
        {
            if (mealContext.Suppliers.Count(x => x.IsDefault == true) != 1)
                throw new Exception($"{MethodName}. Default Supplier not well configured in DB");
            else
                return true;
        }

        public SupplierTO GetDefaultSupplier()
        {
            isDefaultSupplierUniquenessWithThrow("GetCurrentSupplier()");

            return mealContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsDefault == true)
                .ToTranfertsObject();
        }

        public void SetDefaultSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));
            if (Supplier.Id is default(int))
                throw new Exception("Invalid SupplierID");

            var SupplierToMakeCurrent = localRepo.GetById(Supplier.Id);
            SupplierToMakeCurrent.IsDefault = true;

            mealContext.Suppliers
                .UpdateRange(
                    localRepo.GetAll()
                    .Select(x => { x.IsDefault = false; return x.ToEF(); })
                    .ToArray()
                );

            localRepo.Edit(SupplierToMakeCurrent);

            isDefaultSupplierUniquenessWithThrow("SetCurrentSupplier(SupplierTO) after update");
        }

        public override SupplierEF ToEF(SupplierTO transfertObject)
        {
            return transfertObject.ToEF();
        }

        public override SupplierTO ToTransfertObject(SupplierEF entity)
        {
            return entity.ToTranfertsObject();
        }

        public override SupplierEF UpdateFromDetached(SupplierEF AttachedEF, SupplierEF DetachedEF)
        {
            return AttachedEF.UpdateFromDetached(DetachedEF);
        }
    }
}
