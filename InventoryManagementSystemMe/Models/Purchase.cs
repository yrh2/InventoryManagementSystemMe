using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemMe.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        public required string ProductName { get; set; }

        [Display(Name = "Purchased Price")]
        public decimal PurchasedPrice { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Purchased Date")]
        public DateTime PurchasedDate { get; set; }
    }
}
