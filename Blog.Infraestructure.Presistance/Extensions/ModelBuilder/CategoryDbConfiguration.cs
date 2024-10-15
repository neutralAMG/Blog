using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Domain.Entities
{
    public static class CategoryDbConfiguration
    {
        public static ModelBuilder AddCategoryDbConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(c => c.Id);
            });
            return modelBuilder;
        }
    }
}
