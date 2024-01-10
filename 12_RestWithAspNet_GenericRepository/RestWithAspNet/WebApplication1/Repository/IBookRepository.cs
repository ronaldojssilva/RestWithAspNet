using RestWithAspNet.Model;

namespace RestWithAspNet.Repository
{
    public interface IBookRepository
    {
        Book Create(Book Book);
        Book FindById(long id); 
        List<Book> FindAll();
        Book Update(Book Book);
        void Delete(long id);
        bool Exists(long id);
    }
}
