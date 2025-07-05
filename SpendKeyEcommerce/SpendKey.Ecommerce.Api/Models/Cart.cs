using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpendKey.Ecommerce.Api.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }

        public int Product_Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
    }
}
