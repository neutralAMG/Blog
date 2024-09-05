

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Domain.Entities
{
	public class UserBlog : BaseEntity , IBaseSoftDeleteEntity
	{
        public string UserId { get; set; }
        [StringLength(180)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Summary { get; set; }

        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<BlogFavorite> BlogFavorites { get; set; }
        public IList<BlogCategory> BlogCategories { get; set; }

    }
}
