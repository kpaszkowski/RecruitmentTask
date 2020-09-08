using System.Data.Entity;

namespace RecruitmentTask.Models
{
    public class Context : DbContext
    {
        public Context() : base("ReportsDB")
        {
            Database.SetInitializer(new ReportsDbInitializer());
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Premises> Premises { get; set; }
    }
}