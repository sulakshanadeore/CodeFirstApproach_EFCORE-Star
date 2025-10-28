using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproach_EFCORE.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]  
        public string CategroyName { get; set; }

        public string Description { get; set; }
    }
}
