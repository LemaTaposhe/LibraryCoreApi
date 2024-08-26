using System.ComponentModel.DataAnnotations;

namespace LibraryCoreApi.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime DoB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }


        public ICollection<Book>? Books { get; set; }
    }
}
