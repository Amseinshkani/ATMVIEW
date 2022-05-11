using Entity;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class Context : DbContext
    {
        public DbSet<TblUser> tblUsers { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer("Data source =. ; initial Catalog = ATMView; integrated Security = true ;");
        }
    }
}