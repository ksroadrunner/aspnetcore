using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Microsoft.EntityFrameworkCore;
namespace BookStore.Persistence
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var asm = typeof(Domain.BaseEntity).Assembly;
            var entities = asm.GetTypes()
                              .Where(a => a.IsClass
                                          && (a.BaseType == typeof(Domain.BaseEntity))
                                          && !a.GetCustomAttributes(false).Any(t => t is NotMappedAttribute))
                              .ToList();

            entities.ForEach(a => modelBuilder.Entity(a));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=BookStore;Uid=postgres;Pwd=12qwaszxCV!;Pooling=true");
        }
    }
}