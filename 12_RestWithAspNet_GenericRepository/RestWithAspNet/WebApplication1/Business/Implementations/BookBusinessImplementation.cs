using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using RestWithAspNet.Repository;
using System;

namespace RestWithAspNet.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
           return _repository.FindAll();
        }

        public Book FindById(long id) => _repository.FindById(id);

        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }

        public Book Update(Book Book)
        {
            return _repository.Update(Book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
       
    }
}
