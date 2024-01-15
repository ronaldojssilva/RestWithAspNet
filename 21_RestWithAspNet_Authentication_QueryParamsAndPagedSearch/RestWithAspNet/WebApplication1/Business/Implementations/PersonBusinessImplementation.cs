using RestWithAspNet.Data.Converter.Implementation;
using RestWithAspNet.Data.VO;
using RestWithAspNet.Hypermedia.Util;
using RestWithAspNet.Model;
using RestWithAspNet.Repository;

namespace RestWithAspNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
           return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id) => _converter.Parse(_repository.FindById(id));

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var offSet = page > 0 ? (page - 1) * pageSize : 0;
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 1 : pageSize;

            string query = @"select * 
                             from person p
                             where 1=1
                             and p.name like %leo%
                             order by p.name asc limit 10 offset 1";

            var persons = _repository.FindWithPagedSearch(query);
            string countQuery = "";
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = offSet,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults,
            };
        }
    }
}
