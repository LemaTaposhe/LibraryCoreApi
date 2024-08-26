using System.ComponentModel.DataAnnotations;

namespace LibraryCoreApi.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50), Required]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
