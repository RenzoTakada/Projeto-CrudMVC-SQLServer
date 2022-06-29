using Microsoft.EntityFrameworkCore;

namespace WEBCrudSqlServer.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {

        }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
    }
}
