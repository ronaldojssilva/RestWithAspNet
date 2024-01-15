using RestWithAspNet.Data.VO;
using RestWithAspNet.Hypermedia.Util;
using RestWithAspNet.Model;

namespace RestWithAspNet.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO FindById(long id); 

        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        PersonVO Disable(long id);

        void Delete(long id);

        List<PersonVO> FindByName(string firstName, string lastName);
    }
}
