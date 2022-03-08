using BasicApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BasicApp.DAL
{
    public class BasicAppContext : DbContext
    {
        public BasicAppContext() : base("MyConnStrNm")
        {
        }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<PageMetaDetail> PageMetaDetail { get; set; }
        public DbSet<tblUser> tblUser { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}