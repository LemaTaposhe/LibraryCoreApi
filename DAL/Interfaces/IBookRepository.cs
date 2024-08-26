using LibraryCoreApi.Entities;

namespace LibraryCoreApi.DAL.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {
        IEnumerable<Book> GetBooksByAuthor(int authorId);
    IEnumerable<Book> GetBooksByPublisher(int publisherId);
    IEnumerable<Book> GetBooksByCategory(int categoryId);
    IEnumerable<Book> SearchBook(string searchString);
    IEnumerable<Book> GetActiveBooks();
    IEnumerable<Book> GetInActiveBooks();

}
}