using RestWithAspNet.Data.VO;
using RestWithAspNet.Hypermedia.Util;

namespace RestWithAspNet.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO Book);
        BookVO FindById(long id); 
        List<BookVO> FindAll();

        PagedSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirection, int pageSize, int page);

        BookVO Update(BookVO Book);
        void Delete(long id);
    }
}
