namespace SandwichSystem.Shared.BTO
{
    public class SandwichBTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public SupplierBTO Supplier { get; set; }
    }
}