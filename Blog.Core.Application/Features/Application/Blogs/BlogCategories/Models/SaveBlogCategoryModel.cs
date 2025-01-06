
namespace Blog.Core.Application.Features.Application.Blogs.BlogCategories.Models
{
    public class SaveBlogCategoryModel
    {
        public required int BlogId { get; set; }
        public required int CategoryId { get; set; }
    }
}
