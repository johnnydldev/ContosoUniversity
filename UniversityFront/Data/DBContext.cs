using Microsoft.EntityFrameworkCore;

namespace UniversityFront.Data
{
    public class DBContext : DbContext

    {
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }

    }
}
