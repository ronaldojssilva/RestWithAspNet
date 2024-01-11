using RestWithAspNet.Data.Converter.Contract;
using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) 
                return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                launchDate = origin.launchDate,
                Price = origin.Price,
                Title = origin.Title    
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null)
                return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                launchDate = origin.launchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
