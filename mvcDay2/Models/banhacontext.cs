using Microsoft.EntityFrameworkCore;

namespace mvcDay2.Models
{
    public class banhacontext:DbContext
    {
        public banhacontext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-76K89NQ\\MSSQLSERVER01;Database=BanhaITI;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<employee> employees { get; set; }
        public DbSet<Departments> departments { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Work_for> work_Fors { get; set; }
        public DbSet<Dependent> dependents { get; set; }
        
    }
}
