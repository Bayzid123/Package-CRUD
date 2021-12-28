using Microsoft.EntityFrameworkCore;
using PackageCrudRepositoryPattern.Models;

namespace PackageCrudRepositoryPattern.Core
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Package> Packages { get; set; }
    }
}
