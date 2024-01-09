using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;

namespace RestWithAspNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
           return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Ronaldo",
                LastName = "Silva",
                Address = "Fortaleza - Ceará - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
