using System.Data.Entity;

namespace RecruitmentTask.Models
{
    public class Context : DbContext
    {
        public Context() : base("RaportsDB")
        {
            Database.SetInitializer(new RaportsDBInitializer());
        }

        public DbSet<Raport> Raports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Premises> Premises { get; set; }
    }
}