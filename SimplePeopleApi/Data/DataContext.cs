using Microsoft.EntityFrameworkCore;
using SimplePeopleApi.Models;

namespace SimplePeopleApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> People => Set<Person>();
    }
}
