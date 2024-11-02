using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TheTaskContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<TheTask> TheTasks { get; set; }



        public TheTaskContext(DbContextOptions<TheTaskContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().ToTable("Category");
            //modelBuilder.Entity<Category>().HasKey(c => c.Id);
            //modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(150);

            List<Category> categoriesInit = new List<Category>();

            categoriesInit.Add(new Category() { Id = Guid.Parse("78d2ee38-8cd5-4709-a8db-c697966575ef"), Name = "Clothes", Description = "About clothes for men and women" });
            categoriesInit.Add(new Category() { Id = Guid.Parse("3e4edaca-6e16-4826-b413-5194eaad821c"), Name = "Electronic", Description = "About electronic for different situations" });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(c => c.Id);
                category.Property(c => c.Name).IsRequired().HasMaxLength(150);
                category.Property(c => c.Description);
                category.Property(c => c.PropertyTest).IsRequired(false);

                category.HasData(categoriesInit);
            });

            List<TheTask> theTaskInit = new List<TheTask>();
            theTaskInit.Add
                (
                    new TheTask() { Id = Guid.Parse("56f740ff-40fd-47d3-a565-ffc9418544cb"), CategoryId = Guid.Parse("78d2ee38-8cd5-4709-a8db-c697966575ef"), 
                        Title = "Search new words to learn in English", Description = "New vocabulary to study and practicing", 
                        Priority = PriorityEnum.Low, CreatedAt = DateTime.UtcNow,
                        }
                );

            theTaskInit.Add
           (
               new TheTask()
               {
                   Id = Guid.Parse("46d89227-eca6-48c1-a78c-867a064bbd9f"),
                   CategoryId = Guid.Parse("3e4edaca-6e16-4826-b413-5194eaad821c"),
                   Title = "Practice English in platforms where you can speak with other people",
                   Description = "Improving speaking to understand better native speakers",
                   Priority = PriorityEnum.High,
                   CreatedAt = DateTime.UtcNow,
               }
           );

            modelBuilder.Entity<TheTask>(theTask =>
            {

                theTask.ToTable("TheTask");
                theTask.HasKey(tt => tt.Id);

                theTask.HasOne(tt => tt.Category)
                .WithMany(c => c.TheTasks)
                .HasForeignKey(tt => tt.CategoryId);
         

                theTask.Property(tt => tt.Title).IsRequired().HasMaxLength(200);
                theTask.Property(tt => tt.Description);
                theTask.Property(tt => tt.Priority);
                theTask.Property(tt => tt.CreatedAt);
                theTask.Property(tt => tt.Summary);

                theTask.HasData(theTaskInit);
                
            });
        }
    }
}
