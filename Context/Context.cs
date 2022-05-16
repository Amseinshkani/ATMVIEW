using Entity;
using Microsoft.EntityFrameworkCore;

namespace DBContext
{
    public class Context : DbContext
    {
        public DbSet<TblUser> tblUsers { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer("Data source =. ; initial Catalog = MVCATM; integrated Security = true ;");
        }
    }
}