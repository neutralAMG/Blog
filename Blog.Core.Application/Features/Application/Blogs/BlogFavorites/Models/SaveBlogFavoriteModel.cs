
namespace Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Models
{
    public class SaveBlogFavoriteModel
    {
        public required int BlogId { get; set; }
        public required string UserId { get; set; }
    }
}
