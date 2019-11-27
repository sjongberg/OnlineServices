using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.BusinessLayer.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsValid()
        {
            var InvalidSupplier = String.IsNullOrWhiteSpace(Name)
                && String.IsNullOrEmpty(Name);

            if (InvalidSupplier)
                throw new Exception("Supplier not valid;");

            return true;
        }
    }
}
