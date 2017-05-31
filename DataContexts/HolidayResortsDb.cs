using System.Data.Entity;
using HoidayResorts.Data_Entities;

namespace HoidayResorts.DataContexts
{
    public class HolidayResortsDb : DbContext
    {
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}