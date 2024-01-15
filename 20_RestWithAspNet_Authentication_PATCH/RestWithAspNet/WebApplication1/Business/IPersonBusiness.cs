using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id); 
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);

        PersonVO Disable(long id);

        void Delete(long id);
    }
}
