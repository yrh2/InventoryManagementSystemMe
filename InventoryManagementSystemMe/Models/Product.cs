using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemMe.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        public required string ProductName { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Product Quantity")]
        public int ProductQuantity { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Supplier Name")]
        public required string SupplierName { get; set; }

    }
}
