using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproach_EFCORE.Models
{
    public class Product
    {
        [Key]
        public int Prodid { get; set; }

        [Required]
        [MaxLength(30)]
        public string ProdName { get; set; }

        [Required]
        public float Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

    }
}
