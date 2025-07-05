namespace SpendKey.Ecommerce.Api.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailabilityQty { get; set; }
    }
}
