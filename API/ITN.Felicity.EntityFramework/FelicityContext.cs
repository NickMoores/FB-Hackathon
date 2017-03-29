namespace ITN.Felicity.EntityFramework
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FelicityContext : DbContext
    {
        // Your context has been configured to use a 'FelicityContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ITN.Felicity.EntityFramework.FelicityContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FelicityContext' 
        // connection string in the application configuration file.
        public FelicityContext()
            : base("name=Felicity")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Article>()
                .HasMany(Article.Mapping.Feedback)
                .WithRequired()
                .Map(m => m.MapKey("ArticleID"));
        }
    }
}