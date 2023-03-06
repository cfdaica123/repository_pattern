using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReponsitoryExample.Model
{
    public class AppDBContext : DbContext
    {
        public string ConnectionString { get; private set; }
        public DbSet<Category> Categories {get; set;}
        public DbSet<Customer> Customers { get; set; }

        public AppDBContext()
        {
            // var folder = Environment.GetFolderPath(Environment.SpecialFolder.Home);
            // ConnectionString = Path.Combine(folder, "repo.db");
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var pathApp = Path.Combine(folder.ToString(), "repo");
            if (!Directory.Exists(pathApp))
            {
                Directory.CreateDirectory(pathApp);
            }
            ConnectionString = Path.Combine(pathApp, "repo.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={ConnectionString}");
        }
    }

    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Created {get; set;}
        public DateTime Updated { get; set; }
    }

    public class Category : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }
    }
}