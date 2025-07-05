using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpendKey.Ecommerce.Api.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Availability_Qty { get; set; }

        public int Category_Id { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
