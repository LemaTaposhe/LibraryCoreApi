using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryCoreApi.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }


        public string Description { get; set; }
        public string Edition { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
