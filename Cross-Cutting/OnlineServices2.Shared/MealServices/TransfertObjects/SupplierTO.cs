using OnlineServices.Shared.DataAccessHelpers;

namespace OnlineServices.Shared.MealServices.TransfertObjects
{
    public class SupplierTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
