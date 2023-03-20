# DOE.EFWithStoredProcedure

Step One
1. Create Web API Project 
2. Install the following 4 package
		microsoft.entityframeworkcore
		Microsoft.EntityFrameworkCore.Design
		Microsoft.EntityFrameworkCore.SqlServer
		Microsoft.EntityFrameworkCore.Tools
3. Create Your Entities
		

		public class Movie
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public double? Rating { get; set; }
    }

4 Crete MovieContext class and  set up your movie context

public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    5.  register your dbcontect and configue yous services thta you want to ADD

    DOEConfigureServices(builder.Services);

    void DOEConfigureServices(IServiceCollection services)
{
    services.AddDbContext<MovieContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Democonnection")));
    services.AddScoped<IMoviesServices, MoviesServices>();
}

#the ptocedure we are following is code firs so you need to Run DB Migration 
# DB migrationComand

1 Add-migration firstmigration
2.update-database
