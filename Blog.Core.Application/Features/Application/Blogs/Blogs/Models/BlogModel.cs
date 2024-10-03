using Blog.Core.Application.Features.Application.Pots.Pots.Models;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Blogs.Blogs.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int PostCount => Posts != null ? Posts.Count : 0;
        public int FavoriteCount => BlogFavorites != null ? BlogFavorites.Count : 0;
        public DateTime DateCreated { get; set; }
        public List<PostModel> Posts { get; set; }
        public List<BlogFavorite> BlogFavorites { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
    }
}
