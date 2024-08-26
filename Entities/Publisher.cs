namespace LibraryCoreApi.Entities
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }


        public ICollection<Book>? Books { get; set; }
    }
}
