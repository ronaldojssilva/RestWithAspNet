using RestWithAspNet.Model;

namespace RestWithAspNet.Business
{
    public interface IBookBusiness
    {
        Book Create(Book Book);
        Book FindById(long id); 
        List<Book> FindAll();
        Book Update(Book Book);
        void Delete(long id);
    }
}
