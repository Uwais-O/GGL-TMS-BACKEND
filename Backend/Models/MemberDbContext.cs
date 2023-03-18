using Microsoft.EntityFrameworkCore;
namespace Backend2.Models
{

    //Created a database context class to configure context options
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions options) : base(options)
        {
        }

        //Represents entities in database with getters and setters
        public DbSet<Member> Member { get; set; }
        
        //Overriden to specify db provider and connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=gglassessment.database.windows.net;Initial Catalog=BackendGGL;User ID=Uwais;Password=p@ssword123");
        }

    }
}

