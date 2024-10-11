

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Domain.Entities
{
	public class UserBlog : BaseEntity , IBaseSoftDeleteEntity
	{
        public required string UserId { get; set; }
        [StringLength(180)]
        public required string Title { get; set; }
        [StringLength(250)]
        public required string Summary { get; set; }

        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<BlogFavorite>? BlogFavorites { get; set; }
        public ICollection<BlogCategory>? BlogCategories { get; set; }

    }
}
