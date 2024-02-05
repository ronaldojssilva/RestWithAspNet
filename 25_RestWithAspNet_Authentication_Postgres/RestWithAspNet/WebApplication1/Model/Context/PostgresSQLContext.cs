using Microsoft.EntityFrameworkCore;

namespace RestWithAspNet.Model.Context
{
    public class PostgresSQLContext: DbContext
    {
        public PostgresSQLContext()
        {
            
        }

        public PostgresSQLContext(DbContextOptions<PostgresSQLContext> options): base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
