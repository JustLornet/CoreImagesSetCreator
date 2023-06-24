using Microsoft.EntityFrameworkCore;

namespace Me.CoreImagesSetCreator.DataAccess
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}