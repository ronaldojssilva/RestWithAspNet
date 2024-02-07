using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Repository
{
    public interface IPersonRepository: IRepository<Person>
    {
        Person Disable(long id);

        List<Person> FindByName(string firstName, string lastName);
    }
}
