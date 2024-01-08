using Microsoft.EntityFrameworkCore;

namespace RestWithAspNet.Model.Context
{
    public class MySQLcontext: DbContext
    {
        public MySQLcontext()
        {
            
        }

        public MySQLcontext(DbContextOptions<MySQLcontext> options): base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
