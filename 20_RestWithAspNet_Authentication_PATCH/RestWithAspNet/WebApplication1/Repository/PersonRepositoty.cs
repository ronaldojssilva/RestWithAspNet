using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using RestWithAspNet.Repository.Implementations;

namespace RestWithAspNet.Repository
{
    public class PersonRepositoty : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepositoty(MySQLContext context): base(context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;
            var user = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }
    }
}
